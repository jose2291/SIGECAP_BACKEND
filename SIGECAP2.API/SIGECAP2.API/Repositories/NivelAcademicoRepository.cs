using SIGECAP2.API.Data;
using SIGECAP2.API.Models;
using Microsoft.EntityFrameworkCore;

namespace SIGECAP2.API.Repositories
{
    public class NivelAcademicoRepository : INivelAcademicoRepository
    {
        private readonly AppDbContext _context;

        public NivelAcademicoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NivelAcademico>> GetAllAsync()
        {
            return await _context.NivelAcademicos.ToListAsync();
        }

        public async Task<NivelAcademico?> GetByIdAsync(int id)
        {
            return await _context.NivelAcademicos.FindAsync(id);
        }

        public async Task<NivelAcademico> AddAsync(NivelAcademico nivel)
        {
            _context.NivelAcademicos.Add(nivel);
            await _context.SaveChangesAsync();
            return nivel;
        }

        public async Task<NivelAcademico> UpdateAsync(NivelAcademico nivel)
        {
            _context.NivelAcademicos.Update(nivel);
            await _context.SaveChangesAsync();
            return nivel;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.NivelAcademicos.FindAsync(id);
            if (entity == null) return false;

            _context.NivelAcademicos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
