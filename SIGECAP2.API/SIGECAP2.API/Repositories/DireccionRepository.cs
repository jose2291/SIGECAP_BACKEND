using Microsoft.EntityFrameworkCore;
using SIGECAP2.API.Data;
using SIGECAP2.API.Models;

namespace SIGECAP2.API.Repositories
{
    public class DireccionRepository : IDireccionRepository
    {
        private readonly AppDbContext _context;

        public DireccionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Direccion>> GetAllAsync()
        {
            return await _context.Direcciones.ToListAsync();
        }

        public async Task<Direccion?> GetByIdAsync(int id)
        {
            return await _context.Direcciones.FindAsync(id);
        }

        public async Task AddAsync(Direccion direccion)
        {
            _context.Direcciones.Add(direccion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Direccion direccion)
        {
            _context.Direcciones.Update(direccion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var direccion = await _context.Direcciones.FindAsync(id);
            if (direccion != null)
            {
                _context.Direcciones.Remove(direccion);
                await _context.SaveChangesAsync();
            }
        }
    }
}
