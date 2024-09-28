using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudCoreOklab.Data;
using CrudCoreOklab.Models;
using CrudCoreOklab.Models.ViewModels;

namespace CrudCoreOklab.Controllers
{
    public class ProductosController : Controller
    {
        private readonly AppDbContext _context;

        public ProductosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index(string searchString)
        {
            // Pasar el valor de búsqueda a la vista
            ViewData["searchString"] = searchString;

            var productos = _context.Producto.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                productos = productos.Where(p =>
                    p.Codigo.Contains(searchString) ||
                    p.Descripcion.Contains(searchString) ||
                    p.Tipo.Contains(searchString));
            }

            return View(await productos.ToListAsync());
        }


        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Producto
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // GET: Productos/Create
        public async Task<IActionResult> Create()
        {
            // Cargar la lista de proveedores para la lista desplegable
            ViewBag.IdProveedor = new SelectList(await _context.Proveedor.ToListAsync(), "IdProveedor", "NombreComercial");

            return View(new Productos());
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Productos producto)
        {
            
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirige a la vista de índice o lista
            

            // Si hay errores, recargar la lista de proveedores
            ViewBag.IdProveedor = new SelectList(await _context.Proveedor.ToListAsync(), "IdProveedor", "NombreComercial");

            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Producto.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }
            return View(productos);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProducto,Codigo,IdProveedor,Descripcion,Precio,Cantidad,Tipo")] Productos productos)
        {
            if (id != productos.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductosExists(productos.IdProducto))
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
            return View(productos);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Producto
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productos = await _context.Producto.FindAsync(id);
            if (productos != null)
            {
                _context.Producto.Remove(productos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductosExists(int id)
        {
            return _context.Producto.Any(e => e.IdProducto == id);
        }
    }
}
