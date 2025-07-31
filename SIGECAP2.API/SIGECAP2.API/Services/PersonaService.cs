using AutoMapper;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;
using SIGECAP2.API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGECAP2.API.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _repository;
        private readonly IMapper _mapper;

        public PersonaService(IPersonaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CrearPersonaAsync(PersonaDTO personaDto)
        {
            var persona = _mapper.Map<Persona>(personaDto);
            await _repository.InsertarPersonaAsync(persona);
        }

        public async Task<List<PersonaDTO>> ObtenerPersonasAsync()
        {
            var personas = await _repository.ObtenerPersonasAsync();
            return _mapper.Map<List<PersonaDTO>>(personas);
        }

        // ✅ Nuevo método para buscar por número de empleado o identidad
        public async Task<Persona> BuscarPorNumeroOIdentidadAsync(string numeroEmpleado, string dni)
        {
            return await _repository.BuscarPorCriterioAsync(numeroEmpleado, dni);
        }

        public async Task<PersonaDTO?> BuscarPorCriterioAsync(string criterio)
        {
            var persona = await _repository.BuscarPorCriterioAsync(criterio, criterio);
            return persona != null ? _mapper.Map<PersonaDTO>(persona) : null;
        }

    }
}
