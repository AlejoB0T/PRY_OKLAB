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
    public class ProveedoresController : Controller
    {
        private readonly AppDbContext _context;

        public ProveedoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Proveedores
        public async Task<IActionResult> Index(string searchString)
        {
            // Para mantener el valor del campo de búsqueda en la vista
            ViewData["CurrentFilter"] = searchString;

            var proveedores = from p in _context.Proveedor.Include(p => p.TipoDocumento)
                              select p;

            // Filtrar por nombre, documento o nombre comercial si se ha ingresado un término de búsqueda
            if (!string.IsNullOrEmpty(searchString))
            {
                proveedores = proveedores.Where(p => p.Nombre.Contains(searchString)
                                                  || p.NumeroDocumento.Contains(searchString)
                                                  || p.NombreComercial.Contains(searchString));
            }

            return View(await proveedores.ToListAsync());
        }



        // GET: Proveedores/Create
        public IActionResult Create()
        {
            ViewData["IdTipoDocumento"] = new SelectList(_context.TipoDocumento, "IdTipoDocumento", "NombreTipoDocumento");

            return View();
        }

        // POST: Proveedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Proveedor proveedor)
        {
            
                await _context.Proveedor.AddAsync(proveedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            return View(proveedor);
        }

        // GET: Proveedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedor.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return View(proveedor);
        }

        // POST: Proveedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProveedor,IdTipoDocumento,NumeroDocumento,Nombre,NombreComercial,EmailProveedor,Telefono,Direccion,FormaPago,Banco,NumeroCuenta")] Proveedor proveedor)
        {
            if (id != proveedor.IdProveedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proveedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProveedorExists(proveedor.IdProveedor))
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
            return View(proveedor);
        }

        // GET: Proveedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedor
                .FirstOrDefaultAsync(m => m.IdProveedor == id);
            if (proveedor == null)
            {
                return NotFound();
            }

            return View(proveedor);
        }

        // POST: Proveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proveedor = await _context.Proveedor.FindAsync(id);
            if (proveedor != null)
            {
                _context.Proveedor.Remove(proveedor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProveedorExists(int id)
        {
            return _context.Proveedor.Any(e => e.IdProveedor == id);
        }
    }
}
