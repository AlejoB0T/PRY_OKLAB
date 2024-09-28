using System.ComponentModel.DataAnnotations;

namespace CrudCoreOklab.Models
{
    public class TipoDocumento
    {
        [Key]
        public int IdTipoDocumento {  get; set; }
        public required string NombreTipoDocumento { get; set; }
        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Empleado> Empleado { get; set; }
        public virtual ICollection<Proveedor> Proveedor { get; set; }

    }
}
