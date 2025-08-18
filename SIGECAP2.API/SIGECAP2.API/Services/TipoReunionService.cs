using AutoMapper;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;
using SIGECAP2.API.Repositories;

namespace SIGECAP2.API.Services
{
    public class TipoReunionService : ITipoReunionService
    {
        private readonly ITipoReunionRepository _repository;
        private readonly IMapper _mapper;

        public TipoReunionService(ITipoReunionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoReunionDto>> GetAllAsync()
        {
            var lista = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TipoReunionDto>>(lista);
        }

        public async Task<TipoReunionDto?> GetByIdAsync(int id)
        {
            var tipoReunion = await _repository.GetByIdAsync(id);
            return _mapper.Map<TipoReunionDto>(tipoReunion);
        }

        public async Task<TipoReunionDto> AddAsync(CreateTipoReunionDto dto)
        {
            var entity = _mapper.Map<TipoReunion>(dto);
            var creado = await _repository.AddAsync(entity);
            return _mapper.Map<TipoReunionDto>(creado);
        }

        public async Task<TipoReunionDto> UpdateAsync(int id, CreateTipoReunionDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("Tipo de reunión no encontrado");

            _mapper.Map(dto, entity);
            var actualizado = await _repository.UpdateAsync(entity);
            return _mapper.Map<TipoReunionDto>(actualizado);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
