using System.ComponentModel.DataAnnotations;
namespace CrudCoreOklab.Models
{
    public class Productos
    {
        [Key]
        public int IdProducto { get; set; }

        [Required]
        [StringLength(100)]
        public string Codigo { get; set; }

        public int IdProveedor {  get; set; }
        public virtual Proveedor Proveedor { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        [Range(1, 10000)]
        public Decimal Precio { get; set; }

        [Range(0, 10000)]
        public int Cantidad { get; set; }

        [StringLength(200)]
        public string Tipo { get; set; }

    }
}
