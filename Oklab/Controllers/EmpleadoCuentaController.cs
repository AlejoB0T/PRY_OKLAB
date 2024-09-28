using Microsoft.AspNetCore.Mvc;
using CrudCoreOklab.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using CrudCoreOklab.Data;

namespace CrudCoreOklab.Controllers
{
	public class CuentaEmpleadoController : Controller
	{
		private readonly AppDbContext _context;

		public CuentaEmpleadoController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(string usuario, string password)
		{
			// Primero traemos al empleado usando el usuario
			var empleado = _context.Empleado.SingleOrDefault(e => e.UsuarioCorporativoEmpleado == usuario);

			// Si el empleado existe, comparamos la contraseña en memoria
			if (empleado != null && string.Equals(empleado.ContraseñaCorporativaEmpleado, password, StringComparison.OrdinalIgnoreCase))
			{
				var claims = new List<Claim>
		{
			new Claim(ClaimTypes.Name, empleado.NombreEmpleado),
			new Claim("EmpleadoId", empleado.IdEmpleado.ToString()),
			new Claim(ClaimTypes.Role, empleado.RolEmpleado)
		};

				var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

				return RedirectToAction("Dashboard", "Dashboard");
			}

			// Si no se cumple la validación, mostramos el error
			ViewBag.Error = "Usuario y/o contraseña no válidos";
			return View();
		}



		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync("EmployeeScheme");
			return RedirectToAction("Login", "CuentaEmpleado");
		}
	}
}

