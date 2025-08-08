using SIGECAP2.API.Data;
using SIGECAP2.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGECAP2.API.Repositories
{
    public class AccesoriosReservaRepository : IAccesoriosReservaRepository
    {
        private readonly AppDbContext _context;

        public AccesoriosReservaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AccesorioReserva>> ObtenerPorReservaIdAsync(int reservaId)
        {
            return await _context.AccesoriosReserva
                .Where(a => a.ReservaId == reservaId)
                .ToListAsync();
        }

        public async Task CrearAccesoriosReservaAsync(List<AccesorioReserva> accesorios)
        {
            await _context.AccesoriosReserva.AddRangeAsync(accesorios);
            await _context.SaveChangesAsync();
        }
    }
}
