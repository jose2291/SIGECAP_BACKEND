using Microsoft.EntityFrameworkCore;
using SIGECAP2.API.Models;

namespace SIGECAP2.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Contrasena> Contrasenas { get; set; }


    }
}
