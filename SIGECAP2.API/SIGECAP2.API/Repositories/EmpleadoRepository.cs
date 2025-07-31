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

        // ✅ Nuevo método requerido por la interfaz
        public async Task<List<Empleado>> ObtenerTodosAsync()
        {
            return await _context.Empleado.ToListAsync();
        }
    }
}
