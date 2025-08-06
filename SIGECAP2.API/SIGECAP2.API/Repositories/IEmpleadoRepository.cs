using SIGECAP2.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGECAP2.API.Repositories
{
    public interface IEmpleadoRepository
    {
        Task CrearEmpleadoAsync(Empleado empleado);

        // ✅ Método para listar todos los empleados
        Task<List<Empleado>> ObtenerTodosAsync();

        // ✅ Nuevo método para cambiar estado
        Task CambiarEstadoAsync(string numeroEmpleado, bool activo);

        // (Opcional) Método genérico para actualizar empleado
        Task ActualizarEmpleadoAsync(Empleado empleado);
    }
}
