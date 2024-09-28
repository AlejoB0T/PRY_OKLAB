using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrudCoreOklab.Models
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }
        public int IdTipoDocumento { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
        public int DocumentoEmpleado { get; set; }
        [Required]
        [StringLength(100)]
        public string NombreEmpleado { get; set; }
        [Required]
        [StringLength(100)]
        public string ApellidoEmpleado { get; set; }
        [Required]
        public DateTime FechaNacimientoEmpleado { get; set; }
        [Required]
        [StringLength(100)]
        public string CargoEmpleado { get; set; }
        [Required]
        [StringLength(100)]
        public string SalarioEmpleado { get; set; }
        [Required]
        [StringLength(100)]
        public string UsuarioCorporativoEmpleado { get; set; }
        [Required]
        [StringLength(100)]
        public string ContraseñaCorporativaEmpleado { get; set; }
        public string RolEmpleado { get; set; }
        [Required]
        [EmailAddress]
        public string EmailEmpleado { get; set; }
        [Required]
        [StringLength(15)]
        public string CelularEmpleado { get; set; }
        [Required]
        [StringLength(100)]
        public string DireccionEmpleado { get; set; }
        [Required]
        [StringLength(100)]
        public string EstadoCivilEmpleado { get; set; }
        [Required]
        [StringLength(100)]
        public string NumeroHijosEmpleado { get; set; }
        [Required]
        [StringLength(100)]
        public string TipoSangreEmpleado { get; set; }
        [Required]
        [StringLength(100)]
        public string EPSEmpleado { get; set; }
        [Required]
        [StringLength(100)]
        public string FondoPensionEmpleado { get; set; }
        [Required]
        [StringLength(100)]
        public string ARLEmpleado { get; set; }
        [Required]
        [StringLength(100)]
        public string CajaCompensacionEmpleado { get; set; }
        [Required]
        [StringLength(100)]
        public string TipoContratoEmpleado { get; set; }
        [Required]
        public DateTime FechaInicioContratoEmpleado { get; set; }
        [Required]
        [StringLength(100)]
        public string JefeInmediatoEmpleado { get; set; }

    }
}
