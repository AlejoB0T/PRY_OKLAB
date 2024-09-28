using System.ComponentModel.DataAnnotations;
namespace CrudCoreOklab.Models
{
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }
        [Required]
        public int IdTipoDocumento { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }

        [Required]
        public string NumeroDocumento { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        public string NombreComercial { get; set; }

        [Required]
        [EmailAddress]
        public string EmailProveedor { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string FormaPago { get; set; }
        [Required]
        public string Banco { get; set; }
        [Required]
        public string NumeroCuenta { get; set; }
        public virtual ICollection<Productos> Productos { get; set; }
    }
}

