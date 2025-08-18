using Microsoft.EntityFrameworkCore;
using SIGECAP2.API.Data;
using SIGECAP2.API.Models;

namespace SIGECAP2.API.Repositories
{
    public class InstitucionRepository : IInstitucionRepository
    {
        private readonly AppDbContext _context;

        public InstitucionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Institucion>> GetAllAsync()
        {
            return await _context.Instituciones.ToListAsync();
        }

        public async Task<Institucion> GetByIdAsync(int id)
        {
            return await _context.Instituciones.FindAsync(id);
        }

        public async Task AddAsync(Institucion institucion)
        {
            _context.Instituciones.Add(institucion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Institucion institucion)
        {
            _context.Instituciones.Update(institucion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var institucion = await _context.Instituciones.FindAsync(id);
            if (institucion != null)
            {
                _context.Instituciones.Remove(institucion);
                await _context.SaveChangesAsync();
            }
        }
    }
}
