using Microsoft.EntityFrameworkCore;
using SIGECAP2.API.Data;
using SIGECAP2.API.Models;

namespace SIGECAP2.API.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly AppDbContext _context;

        public DepartamentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Departamento>> GetAllAsync() =>
            await _context.Departamentos.ToListAsync();

        public async Task<Departamento> GetByIdAsync(int id) =>
            await _context.Departamentos.FindAsync(id);

        public async Task AddAsync(Departamento departamento)
        {
            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Departamento departamento)
        {
            _context.Departamentos.Update(departamento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dep = await _context.Departamentos.FindAsync(id);
            if (dep != null)
            {
                _context.Departamentos.Remove(dep);
                await _context.SaveChangesAsync();
            }
        }
    }
}