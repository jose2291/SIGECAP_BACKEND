using Microsoft.EntityFrameworkCore;
using SIGECAP2.API.Data;
using SIGECAP2.API.Models;

namespace SIGECAP2.API.Repositories
{
    public class SalonRepository : ISalonRepository
    {
        private readonly AppDbContext _context;

        public SalonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Salon>> GetAllAsync()
        {
            return await _context.Salones.ToListAsync();
        }

        public async Task<Salon> GetByIdAsync(int id)
        {
            return await _context.Salones.FindAsync(id);
        }

        public async Task<Salon> AddAsync(Salon salon)
        {
            _context.Salones.Add(salon);
            await _context.SaveChangesAsync();
            return salon;
        }

        public async Task<Salon> UpdateAsync(Salon salon)
        {
            _context.Salones.Update(salon);
            await _context.SaveChangesAsync();
            return salon;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var salon = await _context.Salones.FindAsync(id);
            if (salon == null) return false;

            _context.Salones.Remove(salon);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
