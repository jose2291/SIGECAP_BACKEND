namespace SIGECAP2.API.DTOs
{
    public class RecursoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }

    public class CreateRecursoDto
    {
        public string Nombre { get; set; } = string.Empty;
    }
}
