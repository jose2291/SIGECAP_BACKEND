using SIGECAP2.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGECAP2.API.Repositories
{
    public interface IEmpleadoRepository
    {
        Task CrearEmpleadoAsync(Empleado empleado);

        // ✅ Método agregado para listar todos los empleados
        Task<List<Empleado>> ObtenerTodosAsync();
    }
}

