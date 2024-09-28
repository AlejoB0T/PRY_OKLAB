using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudCoreOklab.Data;
using CrudCoreOklab.Models;

namespace CrudCoreOklab.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly AppDbContext _context;

        public EmpleadosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index(string searchString)
        {
            // Para mantener el valor del campo de búsqueda en la vista
            ViewData["CurrentFilter"] = searchString;

            var empleados = from e in _context.Empleado.Include(e => e.TipoDocumento)
                            select e;

            // Filtrar por el término de búsqueda si no está vacío
            if (!string.IsNullOrEmpty(searchString))
            {
                empleados = empleados.Where(e => e.NombreEmpleado.Contains(searchString)
                                              || e.ApellidoEmpleado.Contains(searchString)
                                              || e.CargoEmpleado.Contains(searchString));
            }

            return View(await empleados.ToListAsync());
        }

        // GET: Empleados/Details/5


        // GET: Empleados/Create
        public IActionResult Create()
        {
            ViewData["IdTipoDocumento"] = new SelectList(_context.TipoDocumento, "IdTipoDocumento", "NombreTipoDocumento");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Empleado empleado) { 
            
                await _context.Empleado.AddAsync(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            ViewData["IdTipoDocumento"] = new SelectList(_context.TipoDocumento, "IdTipoDocumento", "IdTipoDocumento", empleado.IdTipoDocumento);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["IdTipoDocumento"] = new SelectList(_context.TipoDocumento, "IdTipoDocumento", "IdTipoDocumento", empleado.IdTipoDocumento);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpleado,IdTipoDocumento,DocumentoEmpleado,NombreEmpleado,ApellidoEmpleado,FechaNacimientoEmpleado,CargoEmpleado,SalarioEmpleado,UsuarioCorporativoEmpleado,ContraseñaCorporativaEmpleado,RolEmpleado,EmailEmpleado,CelularEmpleado,DireccionEmpleado,EstadoCivilEmpleado,NumeroHijosEmpleado,TipoSangreEmpleado,EPSEmpleado,FondoPensionEmpleado,ARLEmpleado,CajaCompensacionEmpleado,TipoContratoEmpleado,FechaInicioContratoEmpleado,JefeInmediatoEmpleado")] Empleado empleado)
        {
            if (id != empleado.IdEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.IdEmpleado))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoDocumento"] = new SelectList(_context.TipoDocumento, "IdTipoDocumento", "IdTipoDocumento", empleado.IdTipoDocumento);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .Include(e => e.TipoDocumento)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleado.Remove(empleado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleado.Any(e => e.IdEmpleado == id);
        }
    }
}
