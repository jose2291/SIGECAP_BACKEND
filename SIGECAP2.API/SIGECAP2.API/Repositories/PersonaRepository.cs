using Microsoft.EntityFrameworkCore;
using SIGECAP2.API.Data;
using SIGECAP2.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGECAP2.API.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly AppDbContext _context;

        public PersonaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertarPersonaAsync(Persona persona)
        {
            await _context.Personas.AddAsync(persona);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Persona>> ObtenerPersonasAsync()
        {
            return await _context.Personas.ToListAsync();
        }

        // ✅ Método único y correcto para buscar por número de empleado o identidad
        public async Task<Persona?> BuscarPorCriterioAsync(string numeroEmpleado, string dni)
        {
            return await _context.Personas
                .FirstOrDefaultAsync(p => p.NumeroEmpleado == numeroEmpleado || p.DNI == dni);
        }
    }
}


