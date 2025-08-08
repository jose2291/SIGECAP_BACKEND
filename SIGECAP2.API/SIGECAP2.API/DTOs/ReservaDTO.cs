namespace SIGECAP2.API.DTOs
{
    public class ReservaDTO
    {
        public string ReservadoPor { get; set; }
        public bool Recursiva { get; set; }
        public DateTime? FechaUnica { get; set; }
        public List<DateTime> Fechas { get; set; }
        public TimeSpan HoraDesde { get; set; }
        public TimeSpan HoraHasta { get; set; }
        public string Salon { get; set; }
        public string Tipo { get; set; }
        public List<string> Accesorios { get; set; }
    }
}
