using AutoMapper;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;
using SIGECAP2.API.Repositories;

namespace SIGECAP2.API.Services
{
    public class RecursoService : IRecursoService
    {
        private readonly IRecursoRepository _repository;
        private readonly IMapper _mapper;

        public RecursoService(IRecursoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RecursoDto>> GetAllAsync()
        {
            var recursos = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<RecursoDto>>(recursos);
        }

        public async Task<RecursoDto?> GetByIdAsync(int id)
        {
            var recurso = await _repository.GetByIdAsync(id);
            return _mapper.Map<RecursoDto?>(recurso);
        }

        public async Task<RecursoDto> AddAsync(CreateRecursoDto dto)
        {
            var recurso = _mapper.Map<Recurso>(dto);
            var creado = await _repository.AddAsync(recurso);
            return _mapper.Map<RecursoDto>(creado);
        }

        public async Task<RecursoDto?> UpdateAsync(int id, CreateRecursoDto dto)
        {
            var recurso = await _repository.GetByIdAsync(id);
            if (recurso == null) return null;

            recurso.Nombre = dto.Nombre;
            var actualizado = await _repository.UpdateAsync(recurso);
            return _mapper.Map<RecursoDto?>(actualizado);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
