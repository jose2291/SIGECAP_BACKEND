namespace SIGECAP2.API.DTOs
{
    public class NivelAcademicoDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }

    public class CrearNivelAcademicoDTO
    {
        public string Descripcion { get; set; } = string.Empty;
    }
}
