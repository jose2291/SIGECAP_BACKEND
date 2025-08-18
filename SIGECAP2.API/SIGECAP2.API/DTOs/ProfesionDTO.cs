namespace SIGECAP2.API.DTOs
{
    public class ProfesionDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }

    public class CrearProfesionDTO
    {
        public string Descripcion { get; set; } = string.Empty;
    }
}
