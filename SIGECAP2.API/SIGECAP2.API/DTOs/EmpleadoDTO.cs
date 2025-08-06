namespace SIGECAP2.API.DTOs
{
    public class EmpleadoDTO
    {
        public string NumeroEmpleado { get; set; }
        public string DNI { get; set; }               // ✅ Añadir este campo
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Departamento { get; set; }
        public string Cargo { get; set; }
        public string Estado { get; set; }
        public bool Activo { get; set; }

        public string ContrasenaGenerada { get; set; }// ✅ Añadir este campo
    }
}

