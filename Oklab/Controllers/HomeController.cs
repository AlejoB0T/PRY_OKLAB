using CrudCoreOklab.Models;
using CrudCoreOklab.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CrudCoreOklab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ServicioEmail _servicioEmail;

        public HomeController(ILogger<HomeController> logger, ServicioEmail servicioEmail)
        {
            _logger = logger;
            _servicioEmail = servicioEmail;
        }

        public async Task<IActionResult> EnviarCorreoDePrueba()
        {
            await _servicioEmail.EnviarEmailAsync("", "Correo de Prueba", "Este es un correo de prueba.");
            return Content("Correo enviado exitosamente.");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
