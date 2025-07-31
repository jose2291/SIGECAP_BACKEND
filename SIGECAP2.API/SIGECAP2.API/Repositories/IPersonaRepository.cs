using SIGECAP2.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGECAP2.API.Repositories
{
    public interface IPersonaRepository
    {
        Task InsertarPersonaAsync(Persona persona);
        Task<List<Persona>> ObtenerPersonasAsync();

        // ✅ Nuevo método para búsqueda por número de empleado o identidad
        Task<Persona> BuscarPorCriterioAsync(string numeroEmpleado, string dni);

    }
}
