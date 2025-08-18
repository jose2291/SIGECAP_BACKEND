using Microsoft.EntityFrameworkCore;
using SIGECAP2.API.Data;
using SIGECAP2.API.Models;

namespace SIGECAP2.API.Repositories
{
    public class TipoReunionRepository : ITipoReunionRepository
    {
        private readonly AppDbContext _context;

        public TipoReunionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoReunion>> GetAllAsync()
        {
            return await _context.TipoReuniones.ToListAsync();
        }

        public async Task<TipoReunion?> GetByIdAsync(int id)
        {
            return await _context.TipoReuniones.FindAsync(id);
        }

        public async Task<TipoReunion> AddAsync(TipoReunion tipoReunion)
        {
            _context.TipoReuniones.Add(tipoReunion);
            await _context.SaveChangesAsync();
            return tipoReunion;
        }

        public async Task<TipoReunion> UpdateAsync(TipoReunion tipoReunion)
        {
            _context.TipoReuniones.Update(tipoReunion);
            await _context.SaveChangesAsync();
            return tipoReunion;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tipoReunion = await _context.TipoReuniones.FindAsync(id);
            if (tipoReunion == null) return false;

            _context.TipoReuniones.Remove(tipoReunion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
