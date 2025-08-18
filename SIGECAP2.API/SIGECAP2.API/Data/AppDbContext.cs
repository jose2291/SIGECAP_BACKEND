using Microsoft.EntityFrameworkCore;
using SIGECAP2.API.Models;

namespace SIGECAP2.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Tablas base
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Contrasena> Contrasenas { get; set; }

        // Reservas de salón
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<FechaReserva> FechasReserva { get; set; }
        public DbSet<AccesorioReserva> AccesoriosReserva { get; set; }

        // Catálogos adicionales
        public DbSet<NivelAcademico> NivelAcademicos { get; set; }
        public DbSet<Profesion> Profesiones { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Salon> Salones { get; set; }
        public DbSet<Institucion> Instituciones { get; set; }
        public DbSet<TipoReunion> TiposReunion { get; set; }
        public DbSet<Recurso> Recursos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<TipoReunion> TipoReuniones { get; set; }



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

            modelBuilder.Entity<TipoReunion>(entity =>
            {
                entity.ToTable("TipoReunion");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Descripcion)
                      .IsRequired()
                      .HasMaxLength(150);
            });


            // Nivel Académico
            modelBuilder.Entity<NivelAcademico>(entity =>
            {
                entity.ToTable("NivelAcademico");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Descripcion)
                      .IsRequired()
                      .HasMaxLength(150);
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.ToTable("Direccion");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Descripcion)
                      .IsRequired()
                      .HasMaxLength(150);
            });
            // Profesión
            modelBuilder.Entity<Profesion>(entity =>
            {
                entity.ToTable("Profesion");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Descripcion)
                      .IsRequired()
                      .HasMaxLength(150);
            });

            // Cargo
            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.ToTable("Cargo");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Descripcion)
                      .IsRequired()
                      .HasMaxLength(150);
            });

            // Departamento
            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.ToTable("Departamento");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(150);
            });

            // Salón
            modelBuilder.Entity<Salon>(entity =>
            {
                entity.ToTable("Salon");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(150);
            });

            // Institución
            modelBuilder.Entity<Institucion>(entity =>
            {
                entity.ToTable("Institucion");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(150);
            });

            // Tipo de Reunión
            modelBuilder.Entity<TipoReunion>(entity =>
            {
                entity.ToTable("TipoReunion");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Descripcion)
                      .IsRequired()
                      .HasMaxLength(150);
            });

            // Recurso
            modelBuilder.Entity<Recurso>(entity =>
            {
                entity.ToTable("Recurso");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(150);
            });

            // Rol
            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(150);
            });
        }
    }
}
