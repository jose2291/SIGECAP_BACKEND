using AutoMapper;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;
using SIGECAP2.API.Repositories;

namespace SIGECAP2.API.Services
{
    public class InstitucionService : IInstitucionService
    {
        private readonly IInstitucionRepository _repository;
        private readonly IMapper _mapper;

        public InstitucionService(IInstitucionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InstitucionDTO>> GetAllAsync()
        {
            var lista = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<InstitucionDTO>>(lista);
        }

        public async Task<InstitucionDTO> GetByIdAsync(int id)
        {
            var entidad = await _repository.GetByIdAsync(id);
            return _mapper.Map<InstitucionDTO>(entidad);
        }

        public async Task AddAsync(InstitucionDTO institucionDto)
        {
            var entidad = _mapper.Map<Institucion>(institucionDto);
            await _repository.AddAsync(entidad);
        }

        public async Task UpdateAsync(InstitucionDTO institucionDto)
        {
            var entidad = _mapper.Map<Institucion>(institucionDto);
            await _repository.UpdateAsync(entidad);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
