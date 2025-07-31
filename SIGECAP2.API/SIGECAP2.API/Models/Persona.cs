using System.ComponentModel.DataAnnotations;

namespace SIGECAP2.API.Models
{
    public class Persona
    {
        [Key]
        public int IdPersona { get; set; }

        public string? NumeroEmpleado { get; set; }
        public string? DNI { get; set; }
        public string? Genero { get; set; }
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public string? NivelAcademico { get; set; }
        public string? Profesion { get; set; }
        public string? Cargo { get; set; }
        public string? DireccionPuesto { get; set; }

        // Faltantes ahora opcionales:
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string? Estado { get; set; }
    }
}
