using CrudCoreOklab.Models.ViewModels;
using CrudCoreOklab.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CrudCoreOklab.Data;
using System.Configuration;



namespace CrudCoreOklab.Controllers
{
    public class PasswordResetController : Controller
    {
        private readonly AppDbContext _context;
        private readonly PasswordResetService _passwordResetService;
        private readonly IConfiguration _configuration;

        public PasswordResetController(AppDbContext context, PasswordResetService passwordResetService, IConfiguration configuration)
        {
            _context = context;
            _passwordResetService = passwordResetService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult SendPasswordResetLink(string token, string email)
        {
            return View();
        }

        // Enviar enlace de restablecimiento de contraseña
        [HttpPost]
        public async Task<IActionResult> SendPasswordResetLink(string email)
        {
            var cliente = await _context.Cliente.FirstOrDefaultAsync(c => c.EmailCliente == email);
            if (cliente == null)
            {
                return BadRequest("Email no registrado.");
            }

            var token = _passwordResetService.GeneratePasswordResetToken(cliente);
            await _passwordResetService.SendPasswordResetEmail(cliente, token);

            return Ok("Se ha enviado un enlace para restablecer la contraseña.");
        }

        // Mostrar formulario de restablecimiento de contraseña
        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPasswordViewModel { Token = token, Email = email};
            return View(model);
        }

        // Procesar restablecimiento de contraseña
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {

            var email = model.Email;
            var cliente = await _context.Cliente.FirstOrDefaultAsync(c => c.EmailCliente == model.Email);
            if (cliente == null)
            {
                return BadRequest("Usuario no encontrado.");
            }

            // Validar el token
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(model.Token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return BadRequest("Token inválido o expirado.");
            }

            
            cliente.Contrasenha = model.Password;

            try
            {
                // Verificar si el cliente ya está siendo rastreado
                var entry = _context.Entry(cliente);
                if (entry.State == EntityState.Detached)
                {
                    _context.Attach(cliente);
                }
                entry.State = EntityState.Modified;

                // Guardar los cambios
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Registrar o manejar el error
                return StatusCode(500, $"Error al guardar los cambios: {ex.Message}");
            }

            return RedirectToAction("ResetPasswordConfirmation");
        }

        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
    }

}
