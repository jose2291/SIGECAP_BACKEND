using SIGECAP2.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGECAP2.API.Services
{
    public interface IEmpleadoService
    {
        Task CrearEmpleadoAsync(EmpleadoDTO dto);

        // ✅ Agregar esta línea para solucionar el error
        Task<List<EmpleadoDTO>> ObtenerEmpleadosAsync();
    }
}
