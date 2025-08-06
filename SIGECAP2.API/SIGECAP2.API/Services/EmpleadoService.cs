using AutoMapper;
using SIGECAP2.API.Data;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;
using SIGECAP2.API.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGECAP2.API.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _repository;
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public EmpleadoService(
            IEmpleadoRepository repository,
            IPersonaRepository personaRepository,
            IMapper mapper,
            AppDbContext context)
        {
            _repository = repository;
            _personaRepository = personaRepository;
            _mapper = mapper;
            _context = context;
        }

        // 🔹 Genera contraseña aleatoria de 10 caracteres
        private string GenerarPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@#$%";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task CrearEmpleadoAsync(EmpleadoDTO dto)
        {
            var persona = await _personaRepository.BuscarPorCriterioAsync(dto.NumeroEmpleado, dto.DNI);
            if (persona == null)
                throw new Exception("La persona no fue encontrada con el número de empleado o DNI especificado.");

            var empleado = new Empleado
            {
                NumeroEmpleado = persona.NumeroEmpleado ?? "",
                DNI = persona.DNI ?? "Sin DNI",
                NombreCompleto = string.Join(" ", persona.PrimerNombre, persona.SegundoNombre, persona.PrimerApellido, persona.SegundoApellido).Trim(),
                Correo = persona.Correo ?? "",
                Departamento = persona.DireccionPuesto ?? "",
                Cargo = persona.Cargo ?? "",
                Estado = string.IsNullOrWhiteSpace(persona.Estado) ? "Desconocido" : persona.Estado,
                Activo = dto.Activo
            };

            await _repository.CrearEmpleadoAsync(empleado);

            // 🔹 Generar contraseña y asociarla al empleado
            string password = GenerarPassword();

            var contrasena = new Contrasena
            {
                PasswordGenerada = password,
                IdEmpleado = empleado.IdEmpleado
            };

            _context.Contrasenas.Add(contrasena);
            await _context.SaveChangesAsync();

            dto.ContrasenaGenerada = password;
        }

        public async Task<List<EmpleadoDTO>> ObtenerEmpleadosAsync()
        {
            var lista = await _repository.ObtenerTodosAsync();

            return lista.Select(e => new EmpleadoDTO
            {
                NumeroEmpleado = e.NumeroEmpleado ?? "",
                DNI = string.IsNullOrWhiteSpace(e.DNI) ? "Sin DNI" : e.DNI,
                NombreCompleto = e.NombreCompleto ?? "",
                Correo = e.Correo ?? "",
                Departamento = e.Departamento ?? "",
                Cargo = e.Cargo ?? "",
                Estado = string.IsNullOrWhiteSpace(e.Estado) ? "Desconocido" : e.Estado,
                Activo = e.Activo
            }).ToList();
        }

        // ✅ Nuevo método para cambiar estado
        public async Task<bool> CambiarEstadoAsync(string numeroEmpleado, bool activo)
        {
            var empleado = await _context.Empleado.FirstOrDefaultAsync(e => e.NumeroEmpleado == numeroEmpleado);
            if (empleado == null)
                return false;

            empleado.Activo = activo;
            empleado.Estado = activo ? "Activo" : "Inactivo";

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
