using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudCoreOklab.Data;
using CrudCoreOklab.Models;
using CrudCoreOklab.Migrations;

namespace CrudCoreOklab.Controllers
{
    public class ReservasController : Controller
    {
        private readonly AppDbContext _context;

        public ReservasController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var reservas = _context.Reserva
                .Include(r => r.Habitacion)
                .Include(r => r.Cliente)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                reservas = reservas.Where(r =>
                    r.IdentificadorUnico.Contains(searchString) ||
                    r.Cliente.NombreCliente.Contains(searchString) ||
                    r.Cliente.ApellidoCliente.Contains(searchString) ||
                    r.Habitacion.NombreHabitacion.Contains(searchString));
            }

            return View(await reservas.ToListAsync());
        }
        
        public async Task<IActionResult> Historial(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservas = await _context.Reserva
                .Include(r => r.Habitacion)
                .Where(r => r.IdCliente == id)
                .ToListAsync();

            if (reservas == null || reservas.Count == 0)
            {
                return NotFound();
            }

            return View(reservas);
        }


        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Habitacion)
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reservas/Create
        public IActionResult Create(int idCliente)
        {
            var modelo = new Reserva
            {
                IdCliente = idCliente,
                FechaInicio = DateTime.Today, 
                FechaFin = DateTime.Now.AddDays(1), 
            };
            ViewData["NombreHabitacion"] = new SelectList(_context.Set<Habitacion>(), "IdHabitacion", "NombreHabitacion");
            return View(modelo);
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(Reserva reserva, int idCliente)
        {

            if (idCliente == null)
            {
                ModelState.AddModelError("", "El ID del cliente no puede ser nulo.");
                ViewData["NombreHabitacion"] = new SelectList(_context.Set<Habitacion>(), "IdHabitacion", "NombreHabitacion");
                return View(reserva);
            }
            // Verifica si el cliente existe
            var cliente = await _context.Cliente.FindAsync(idCliente);
            if (cliente == null)
            {
                ModelState.AddModelError("", "Cliente no encontrado.");
                ViewData["NombreHabitacion"] = new SelectList(_context.Set<Habitacion>(), "IdHabitacion", "NombreHabitacion");
                return View(reserva);
            }

            string prefijoHabitacion = ObtenerPrefijoHabitacion(reserva.NombreHabitacion);
            int numeroReserva = _context.Reserva.Count(r => r.NombreHabitacion == reserva.NombreHabitacion) + 1;
            reserva.GenerarIdentificadorUnico(prefijoHabitacion, numeroReserva);

            if (reserva.FechaInicio < DateTime.Today)
            {
                ModelState.AddModelError("FechaInicio", "La fecha de inicio no puede ser una fecha pasada.");
            }
            if (reserva.FechaFin <= reserva.FechaInicio)
            {
                ModelState.AddModelError("FechaFin", "La fecha de fin debe ser al menos un día después de la fecha de inicio.");
            }


            bool Disponible = !_context.Reserva.Any(r =>
                r.NombreHabitacion == reserva.NombreHabitacion &&
                r.FechaInicio < reserva.FechaFin &&
                r.FechaFin > reserva.FechaInicio);

            
                if (!Disponible)
                {
                    ModelState.AddModelError("", "La habitación ya está reservada en el rango de fechas especificado.");
                    ViewData["NombreHabitacion"] = new SelectList(_context.Set<Habitacion>(), "IdHabitacion", "NombreHabitacion");
                    return View(reserva);
                }
                else
                {
                    reserva.IdCliente = idCliente;
                    await _context.Reserva.AddAsync(reserva);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Reservas", new { id = reserva.IdReserva, IdCliente = reserva.IdCliente });
                }
            

            ViewData["NombreHabitacion"] = new SelectList(_context.Set<Habitacion>(), "IdHabitacion", "NombreHabitacion");
            return View(reserva);
        }

        private string ObtenerPrefijoHabitacion(int nombreHabitacion)
        {
            // Aquí mapeas los nombres de habitaciones a sus prefijos correspondientes
            switch (nombreHabitacion)
            {
                case 1: return "HBO"; // Habitacion O
                case 2: return "HBK"; // Habitacion K
                case 3: return "HBL"; // Habitacion L
                case 4: return "HBA"; // Habitacion A
                case 5: return "HBB"; // Habitacion B
                default: return "HBX"; // Prefijo por defecto si no coincide
            }
        }

        

        private bool ReservaExists(int  id)
        {
            return _context.Reserva.Any(e => e.IdReserva == id);
        }
    }
}
