using Microsoft.EntityFrameworkCore;
using SIGECAP2.API.Data;
using SIGECAP2.API.Models;

namespace SIGECAP2.API.Repositories
{
    public class RecursoRepository : IRecursoRepository
    {
        private readonly AppDbContext _context;

        public RecursoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Recurso>> GetAllAsync()
        {
            return await _context.Recursos.ToListAsync();
        }

        public async Task<Recurso?> GetByIdAsync(int id)
        {
            return await _context.Recursos.FindAsync(id);
        }

        public async Task<Recurso> AddAsync(Recurso recurso)
        {
            _context.Recursos.Add(recurso);
            await _context.SaveChangesAsync();
            return recurso;
        }

        public async Task<Recurso?> UpdateAsync(Recurso recurso)
        {
            var existente = await _context.Recursos.FindAsync(recurso.Id);
            if (existente == null) return null;

            existente.Nombre = recurso.Nombre;
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var recurso = await _context.Recursos.FindAsync(id);
            if (recurso == null) return false;

            _context.Recursos.Remove(recurso);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
