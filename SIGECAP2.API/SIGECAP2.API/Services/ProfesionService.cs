using AutoMapper;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;
using SIGECAP2.API.Repositories;

namespace SIGECAP2.API.Services
{
    public class ProfesionService : IProfesionService
    {
        private readonly IProfesionRepository _repository;
        private readonly IMapper _mapper;

        public ProfesionService(IProfesionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProfesionDTO>> GetAllAsync()
        {
            var profesiones = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProfesionDTO>>(profesiones);
        }

        public async Task<ProfesionDTO?> GetByIdAsync(int id)
        {
            var profesion = await _repository.GetByIdAsync(id);
            return profesion == null ? null : _mapper.Map<ProfesionDTO>(profesion);
        }

        public async Task<ProfesionDTO> AddAsync(CrearProfesionDTO dto)
        {
            var entity = _mapper.Map<Profesion>(dto);
            var saved = await _repository.AddAsync(entity);
            return _mapper.Map<ProfesionDTO>(saved);
        }

        public async Task<ProfesionDTO> UpdateAsync(ProfesionDTO dto)
        {
            var entity = _mapper.Map<Profesion>(dto);
            var updated = await _repository.UpdateAsync(entity);
            return _mapper.Map<ProfesionDTO>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
