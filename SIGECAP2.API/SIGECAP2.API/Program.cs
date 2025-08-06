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

// Agregar AutoMapper y EF Core
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositorios
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();

// Servicios
builder.Services.AddScoped<IPersonaService, PersonaService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(PersonaProfile));
builder.Services.AddAutoMapper(typeof(EmpleadoProfile));

// CORS global
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()   // Permite cualquier origen en desarrollo
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

// Activar CORS global
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
