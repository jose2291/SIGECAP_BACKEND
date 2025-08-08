using SIGECAP2.API.DTOs;

namespace SIGECAP2.API.Services
{
    public interface IReservaService
    {
        Task CrearReservaAsync(ReservaDTO dto);
        Task<List<ReservaDTO>> ObtenerReservasAsync();
    }
}
