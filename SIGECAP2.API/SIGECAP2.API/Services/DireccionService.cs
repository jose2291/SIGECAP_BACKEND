using AutoMapper;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;
using SIGECAP2.API.Repositories;

namespace SIGECAP2.API.Services
{
    public class DireccionService : IDireccionService
    {
        private readonly IDireccionRepository _repository;
        private readonly IMapper _mapper;

        public DireccionService(IDireccionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DireccionDTO>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DireccionDTO>>(list);
        }

        public async Task<DireccionDTO?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<DireccionDTO?>(entity);
        }

        public async Task<DireccionDTO> AddAsync(DireccionDTO dto)
        {
            var entity = _mapper.Map<Direccion>(dto);
            await _repository.AddAsync(entity);
            return _mapper.Map<DireccionDTO>(entity);
        }

        public async Task<DireccionDTO?> UpdateAsync(int id, DireccionDTO dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            entity.Descripcion = dto.Descripcion;
            await _repository.UpdateAsync(entity);
            return _mapper.Map<DireccionDTO>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
