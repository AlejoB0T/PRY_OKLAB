using CrudCoreOklab.Data;
using CrudCoreOklab.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrudCoreOklab.Controllers
{
   
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            var totalReservas = _context.Reserva.Count();

            // Llenar el modelo de líneas (Reservas por mes)
            List<LineaViewModel> listaReservas = _context.Reserva
                .GroupBy(r => r.FechaInicio.Month)  // Agrupa por mes
                .Select(g => new LineaViewModel
                {
                    Meses = new DateTime(1, g.Key, 1).ToString("MMMM"), // Convertir el número del mes al nombre del mes
                    CantidadReservas = g.Count() // Contar las reservas en ese mes
                })
                .ToList();

            // Llenar el modelo de pie (Habitación favorita)
            List<PieViewModel> listaHabitacion = _context.Reserva
                .GroupBy(r => r.NombreHabitacion) // Agrupar por ID de la habitación
                .Select(g => new PieViewModel
                {
                    Habitacion = _context.Habitacion.FirstOrDefault(h => h.IdHabitacion == g.Key).NombreHabitacion ?? "Desconocida", // Obtener el nombre de la habitación // Obtener el nombre de la habitación
                    Porcentaje = (double)g.Count() / totalReservas * 100 // Calcular el porcentaje
                })
                .ToList();

            // Llenar el ViewModel combinado
            var dashboardViewModel = new DashboardViewModel
            {
                ReservasPorMes = listaReservas,
                HabitacionFavorita = listaHabitacion
            };

            return View(dashboardViewModel);
        }

        // To-Do; Agregar ViewModel y Metodo para ver el Grafico de Barras :D
    }
}
