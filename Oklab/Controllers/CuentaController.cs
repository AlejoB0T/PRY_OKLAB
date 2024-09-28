using Microsoft.AspNetCore.Mvc;
using CrudCoreOklab.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using CrudCoreOklab.Data;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using CrudCoreOklab.Servicios;

namespace CrudCoreOklab.Controllers
{
    public class CuentaController : Controller
    {
        private readonly AppDbContext _context;

        public CuentaController(AppDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string documento, string password)
        {
            var cliente = _context.Cliente.SingleOrDefault(c => c.DocumentoCliente == documento && c.Contrasenha == password);

            if (cliente != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, cliente.NombreCliente),
                    new Claim("ClienteId", cliente.IdCliente.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Historial", "Reservas", new { id = cliente.IdCliente });
            }

            ViewBag.Error = "Usuario y/o contraseña no validos";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Cuenta");
        }
        
    }
}
