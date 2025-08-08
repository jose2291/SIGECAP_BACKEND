using SIGECAP2.API.Data;
using SIGECAP2.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGECAP2.API.Repositories
{
    public class FechaReservaRepository : IFechaReservaRepository
    {
        private readonly AppDbContext _context;

        public FechaReservaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<FechaReserva>> ObtenerPorReservaIdAsync(int reservaId)
        {
            return await _context.FechasReserva
                .Where(f => f.ReservaId == reservaId)
                .ToListAsync();
        }

        public async Task CrearFechasReservaAsync(List<FechaReserva> fechas)
        {
            await _context.FechasReserva.AddRangeAsync(fechas);
            await _context.SaveChangesAsync();
        }
    }
}
