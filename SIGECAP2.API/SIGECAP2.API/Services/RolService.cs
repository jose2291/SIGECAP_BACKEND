using AutoMapper;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;
using SIGECAP2.API.Repositories;

namespace SIGECAP2.API.Services
{
    public class RolService : IRolService
    {
        private readonly IRolRepository _repository;
        private readonly IMapper _mapper;

        public RolService(IRolRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RolDto>> GetAllAsync()
        {
            var roles = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<RolDto>>(roles);
        }

        public async Task<RolDto?> GetByIdAsync(int id)
        {
            var rol = await _repository.GetByIdAsync(id);
            return _mapper.Map<RolDto?>(rol);
        }

        public async Task<RolDto> AddAsync(RolDto dto)
        {
            var entity = _mapper.Map<Rol>(dto);
            var added = await _repository.AddAsync(entity);
            return _mapper.Map<RolDto>(added);
        }

        public async Task<RolDto> UpdateAsync(RolDto dto)
        {
            var entity = _mapper.Map<Rol>(dto);
            var updated = await _repository.UpdateAsync(entity);
            return _mapper.Map<RolDto>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
