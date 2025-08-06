using SIGECAP2.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGECAP2.API.Services
{
    public interface IEmpleadoService
    {
        Task CrearEmpleadoAsync(EmpleadoDTO dto);
        Task<List<EmpleadoDTO>> ObtenerEmpleadosAsync();
        Task<bool> CambiarEstadoAsync(string numeroEmpleado, bool activo);
    }
}
