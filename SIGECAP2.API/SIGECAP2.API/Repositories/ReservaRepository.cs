using SIGECAP2.API.Data;
using SIGECAP2.API.Models;
using Microsoft.EntityFrameworkCore;


namespace SIGECAP2.API.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly AppDbContext _context;

        public ReservaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CrearReservaAsync(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Reserva>> ObtenerReservasAsync()
        {
            return await _context.Reservas
                .Include(r => r.Fechas)
                .Include(r => r.Accesorios)
                .ToListAsync();
        }
    }

}
