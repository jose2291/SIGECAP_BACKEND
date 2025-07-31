using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;
using SIGECAP2.API.Repositories;
using AutoMapper;
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

        public EmpleadoService(IEmpleadoRepository repository, IPersonaRepository personaRepository, IMapper mapper)
        {
            _repository = repository;
            _personaRepository = personaRepository;
            _mapper = mapper;
        }

        public async Task CrearEmpleadoAsync(EmpleadoDTO dto)
        {
            var persona = await _personaRepository.BuscarPorCriterioAsync(dto.NumeroEmpleado, dto.DNI);
            if (persona == null)
                throw new System.Exception("La persona no fue encontrada con el número de empleado o DNI especificado.");

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
        }

        public async Task<List<EmpleadoDTO>> ObtenerEmpleadosAsync()
        {
            var lista = await _repository.ObtenerTodosAsync();

            var listaDto = lista.Select(e => new EmpleadoDTO
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

            return listaDto;
        }
    }
}
