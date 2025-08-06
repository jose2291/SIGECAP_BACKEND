using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGECAP2.API.Models
{
    public class Contrasena
    {
        [Key]
        public int IdContrasena { get; set; }

        [Required]
        public string PasswordGenerada { get; set; }

        [Required]
        [ForeignKey("Empleado")]
        public int IdEmpleado { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public Empleado Empleado { get; set; }
    }
}
