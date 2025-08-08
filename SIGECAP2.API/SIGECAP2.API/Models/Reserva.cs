namespace SIGECAP2.API.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public string ReservadoPor { get; set; }
        public bool Recursiva { get; set; }
        public DateTime? FechaUnica { get; set; }
        public TimeSpan HoraDesde { get; set; }
        public TimeSpan HoraHasta { get; set; }
        public string Salon { get; set; }
        public string Tipo { get; set; }

        public List<FechaReserva> Fechas { get; set; }
        public List<AccesorioReserva> Accesorios { get; set; }
    }
}
