namespace SIGECAP2.API.Models
{
    public class FechaReserva
    {
        public int Id { get; set; }
        public int ReservaId { get; set; }
        public DateTime Fecha { get; set; }

        public Reserva Reserva { get; set; }
    }
}
