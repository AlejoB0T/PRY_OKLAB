using System.Collections.Generic;
using CrudCoreOklab.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrudCoreOklab.Models.ViewModels
{
    public class ProductosViewModel
    {
        public Productos Producto { get; set; } // Producto que se va a crear
        public List<Productos> ListaProductos { get; set; } // Lista de productos existentes
        public SelectList Proveedores { get; set; }
    }
}
