using SIGECAP2.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGECAP2.API.Repositories
{
    public interface IAccesoriosReservaRepository
    {
        Task<List<AccesorioReserva>> ObtenerPorReservaIdAsync(int reservaId);
        Task CrearAccesoriosReservaAsync(List<AccesorioReserva> accesorios);
    }
}
