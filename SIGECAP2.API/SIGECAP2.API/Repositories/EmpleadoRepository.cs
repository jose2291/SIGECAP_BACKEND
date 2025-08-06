using SIGECAP2.API.Data;
using SIGECAP2.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGECAP2.API.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly AppDbContext _context;

        public EmpleadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CrearEmpleadoAsync(Empleado empleado)
        {
            _context.Empleado.Add(empleado);
            await _context.SaveChangesAsync();
        }

        // ✅ Nuevo método para listar todos los empleados
        public async Task<List<Empleado>> ObtenerTodosAsync()
        {
            return await _context.Empleado.ToListAsync();
        }

        // ✅ Nuevo método para cambiar estado Activo/Inactivo
        public async Task CambiarEstadoAsync(string numeroEmpleado, bool activo)
        {
            var empleado = await _context.Empleado.FirstOrDefaultAsync(e => e.NumeroEmpleado == numeroEmpleado);
            if (empleado != null)
            {
                empleado.Activo = activo;
                empleado.Estado = activo ? "Activo" : "Inactivo";
                await _context.SaveChangesAsync();
            }
        }

        // (Opcional) Método genérico para actualizar empleado si se requiere en el futuro
        public async Task ActualizarEmpleadoAsync(Empleado empleado)
        {
            _context.Empleado.Update(empleado);
            await _context.SaveChangesAsync();
        }
    }
}
