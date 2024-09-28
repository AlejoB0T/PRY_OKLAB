using CrudCoreOklab.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace CrudCoreOklab.Servicios
{
    public class PasswordResetService
    {
        private readonly IConfiguration _configuration;
        private readonly ServicioEmail _servicioEmail;

        public PasswordResetService(IConfiguration configuration, ServicioEmail servicioEmail)
        {
            _configuration = configuration;
            _servicioEmail = servicioEmail;
        }

        public string GeneratePasswordResetToken(Cliente cliente)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("Email", cliente.EmailCliente),
                new Claim("ClienteId", cliente.IdCliente.ToString())
            }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Jwt:ExpireMinutes"])),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task SendPasswordResetEmail(Cliente cliente, string token)
        {
            var resetLink = $"https://localhost:44338/PasswordReset/ResetPassword?token={token}&email={cliente.EmailCliente}";
            var subject = "Restablecimiento de contraseña";
            var body = $"Haga clic en el siguiente enlace para restablecer su contraseña: <a href='{resetLink}'>Restablecer Contraseña</a>";

            await _servicioEmail.EnviarEmailAsync(cliente.EmailCliente, subject, body);
        }
    }

}
