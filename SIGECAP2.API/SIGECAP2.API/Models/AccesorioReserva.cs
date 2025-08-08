namespace SIGECAP2.API.Models
{
    public class AccesorioReserva
    {
        public int Id { get; set; }
        public int ReservaId { get; set; }
        public string Accesorio { get; set; }

        public Reserva Reserva { get; set; }
    }
}
