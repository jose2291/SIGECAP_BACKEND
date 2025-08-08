using SIGECAP2.API.Models;

namespace SIGECAP2.API.Repositories
{
    public interface IReservaRepository
    {
        Task CrearReservaAsync(Reserva reserva);
        Task<List<Reserva>> ObtenerReservasAsync();
    }
}
