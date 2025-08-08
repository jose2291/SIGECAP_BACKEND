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

        // Nuevas tablas para reservas de salón
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<FechaReserva> FechasReserva { get; set; }
        public DbSet<AccesorioReserva> AccesoriosReserva { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de relaciones para Reservas
            modelBuilder.Entity<Reserva>()
                .HasMany(r => r.Fechas)
                .WithOne(f => f.Reserva)
                .HasForeignKey(f => f.ReservaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reserva>()
                .HasMany(r => r.Accesorios)
                .WithOne(a => a.Reserva)
                .HasForeignKey(a => a.ReservaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
