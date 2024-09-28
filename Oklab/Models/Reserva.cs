using CrudCoreOklab.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace CrudCoreOklab.Models
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; } 
        [Required]
        public string IdentificadorUnico { get; set; }
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        [Required(ErrorMessage = "La fecha de inicio es requerida.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Inicio")]
        public DateTime FechaInicio { get; set; }
        [Required(ErrorMessage = "La fecha de fin es requerida.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Fin")]
        [CustomValidation(typeof(Reserva), nameof(ValidarFechaFin))]
        public DateTime FechaFin { get; set; }
        public int NombreHabitacion { get; set; }
        public virtual Habitacion Habitacion { get; set; }


        public Reserva() { }

        public Reserva(DateTime fechaInicio, DateTime fechaFin,
            int nombreHabitacion)
        {
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            NombreHabitacion = nombreHabitacion;
        }
        public static ValidationResult ValidarFechaFin(DateTime fechaFin, ValidationContext context)
        {
            var instance = context.ObjectInstance as Reserva;
            if (instance == null)
            {
                return new ValidationResult("Instancia inválida.");
            }

            if (fechaFin <= instance.FechaInicio)
            {
                return new ValidationResult("La fecha de fin debe ser al menos un día después de la fecha de inicio.");
            }

            return ValidationResult.Success;
        }

        public void GenerarIdentificadorUnico(string prefijo, int numeroReserva)
        {
            IdentificadorUnico = $"{prefijo}{numeroReserva:D3}";
        }
    }
}
