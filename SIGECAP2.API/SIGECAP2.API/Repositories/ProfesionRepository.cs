using Microsoft.EntityFrameworkCore;
using SIGECAP2.API.Data;
using SIGECAP2.API.Models;

namespace SIGECAP2.API.Repositories
{
    public class ProfesionRepository : IProfesionRepository
    {
        private readonly AppDbContext _context;

        public ProfesionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Profesion>> GetAllAsync()
        {
            return await _context.Profesiones.ToListAsync();
        }

        public async Task<Profesion?> GetByIdAsync(int id)
        {
            return await _context.Profesiones.FindAsync(id);
        }

        public async Task<Profesion> AddAsync(Profesion profesion)
        {
            _context.Profesiones.Add(profesion);
            await _context.SaveChangesAsync();
            return profesion;
        }

        public async Task<Profesion> UpdateAsync(Profesion profesion)
        {
            _context.Profesiones.Update(profesion);
            await _context.SaveChangesAsync();
            return profesion;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Profesiones.FindAsync(id);
            if (entity == null) return false;

            _context.Profesiones.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
