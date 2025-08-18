using Microsoft.EntityFrameworkCore;
using SIGECAP2.API.Data;
using SIGECAP2.API.Mappings;
using SIGECAP2.API.Repositories;
using SIGECAP2.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ================== DbContext ==================
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ================== Repositorios existentes ==================
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();

// ================== Servicios existentes ==================
builder.Services.AddScoped<IPersonaService, PersonaService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();

// ================== Reservas ==================
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<IFechaReservaRepository, FechaReservaRepository>();
builder.Services.AddScoped<IAccesoriosReservaRepository, AccesoriosReservaRepository>();
builder.Services.AddScoped<IReservaService, ReservaService>();

// ================== Nivel Académico ==================
builder.Services.AddScoped<INivelAcademicoRepository, NivelAcademicoRepository>();
builder.Services.AddScoped<INivelAcademicoService, NivelAcademicoService>();

// ================== Profesión ==================
builder.Services.AddScoped<IProfesionRepository, ProfesionRepository>();
builder.Services.AddScoped<IProfesionService, ProfesionService>();

// ================== Dirección ==================
builder.Services.AddScoped<IDireccionRepository, DireccionRepository>();
builder.Services.AddScoped<IDireccionService, DireccionService>();

// ================== Departamento ==================
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();

// ================== Salón ==================
builder.Services.AddScoped<ISalonRepository, SalonRepository>();
builder.Services.AddScoped<ISalonService, SalonService>();

// ================== Institución ==================
builder.Services.AddScoped<IInstitucionRepository, InstitucionRepository>();
builder.Services.AddScoped<IInstitucionService, InstitucionService>();

// ================== Tipo de Reunión ==================
builder.Services.AddScoped<ITipoReunionRepository, TipoReunionRepository>();
builder.Services.AddScoped<ITipoReunionService, TipoReunionService>();

// ================== Recurso ==================
builder.Services.AddScoped<IRecursoRepository, RecursoRepository>();
builder.Services.AddScoped<IRecursoService, RecursoService>();

// ================== Rol ==================
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IRolService, RolService>();

// ================== Cargo ==================
builder.Services.AddScoped<ICargoRepository, CargoRepository>();
builder.Services.AddScoped<ICargoService, CargoService>();

// ================== AutoMapper ==================
builder.Services.AddAutoMapper(typeof(PersonaProfile));
builder.Services.AddAutoMapper(typeof(EmpleadoProfile));
builder.Services.AddAutoMapper(typeof(ReservaProfile));
builder.Services.AddAutoMapper(typeof(NivelAcademicoProfile));
builder.Services.AddAutoMapper(typeof(ProfesionProfile));
builder.Services.AddAutoMapper(typeof(DireccionProfile));
builder.Services.AddAutoMapper(typeof(DepartamentoProfile));
builder.Services.AddAutoMapper(typeof(SalonProfile));
builder.Services.AddAutoMapper(typeof(InstitucionProfile));
builder.Services.AddAutoMapper(typeof(TipoReunionProfile));
builder.Services.AddAutoMapper(typeof(RecursoProfile));
builder.Services.AddAutoMapper(typeof(RolProfile));
builder.Services.AddAutoMapper(typeof(CargoProfile)); // 👈 agregado

// ================== CORS global ==================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();
