using AutoMapper;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;
using SIGECAP2.API.Repositories;

namespace SIGECAP2.API.Services
{
    public class NivelAcademicoService : INivelAcademicoService
    {
        private readonly INivelAcademicoRepository _repository;
        private readonly IMapper _mapper;

        public NivelAcademicoService(INivelAcademicoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NivelAcademicoDTO>> GetAllAsync()
        {
            var niveles = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<NivelAcademicoDTO>>(niveles);
        }

        public async Task<NivelAcademicoDTO?> GetByIdAsync(int id)
        {
            var nivel = await _repository.GetByIdAsync(id);
            return nivel == null ? null : _mapper.Map<NivelAcademicoDTO>(nivel);
        }

        public async Task<NivelAcademicoDTO> AddAsync(CrearNivelAcademicoDTO dto)
        {
            var entity = _mapper.Map<NivelAcademico>(dto);
            var saved = await _repository.AddAsync(entity);
            return _mapper.Map<NivelAcademicoDTO>(saved);
        }

        public async Task<NivelAcademicoDTO> UpdateAsync(NivelAcademicoDTO dto)
        {
            var entity = _mapper.Map<NivelAcademico>(dto);
            var updated = await _repository.UpdateAsync(entity);
            return _mapper.Map<NivelAcademicoDTO>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
