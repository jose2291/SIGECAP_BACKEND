using System.ComponentModel.DataAnnotations;

namespace SIGECAP2.API.Models
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }

        public string NumeroEmpleado { get; set; }
        public string DNI { get; set; }                  // ✅ Agregado
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Departamento { get; set; }
        public string Cargo { get; set; }
        public string Estado { get; set; }
        public bool Activo { get; set; }
        public Contrasena Contrasena { get; set; }

    }
}

