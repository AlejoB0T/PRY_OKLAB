using System.ComponentModel.DataAnnotations;

namespace CrudCoreOklab.Models
{
    public class Habitacion
    {
        [Key]
        public int IdHabitacion { get; set; }
        public required string NombreHabitacion { get; set; }

        public virtual ICollection<Reserva> Reserva { get; set; }


    }
}
