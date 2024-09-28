using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CrudCoreOklab.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        public required int IdTipoDocumento { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }

        [Required(ErrorMessage = "El documento del cliente es requerido.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El documento solo puede contener números.")]
        public string DocumentoCliente { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "La contraseña debe tener entre 5 y 15 caracteres.")]
        public string Contrasenha { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es requerido.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El nombre solo puede contener letras.")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 15 caracteres.")]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "El apellido del cliente es requerido.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El apellido solo puede contener letras.")]
        [StringLength(50, ErrorMessage = "El apellido no puede tener más de 15 caracteres.")]
        public string ApellidoCliente { get; set; }

        [Required(ErrorMessage = "El email del cliente es requerido.")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido.")]
        public string EmailCliente { get; set; }

        [Required(ErrorMessage = "El celular del cliente es requerido.")]
        [RegularExpression(@"^\d{1,15}$", ErrorMessage = "El celular solo puede contener números y no más de 15 caracteres.")]
        public string CelularCliente { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }

    }
}
