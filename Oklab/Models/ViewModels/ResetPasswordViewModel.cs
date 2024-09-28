using System.ComponentModel.DataAnnotations;

namespace CrudCoreOklab.Models.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "El email es requerido.")]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La nueva contraseña es requerida.")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "La contraseña debe tener entre 5 y 15 caracteres.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Debe confirmar la contraseña.")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }

}
