using SIGECAP2.API.DTOs;

namespace SIGECAP2.API.Services
{
    public interface ITipoReunionService
    {
        Task<IEnumerable<TipoReunionDto>> GetAllAsync();
        Task<TipoReunionDto?> GetByIdAsync(int id);
        Task<TipoReunionDto> AddAsync(CreateTipoReunionDto dto);
        Task<TipoReunionDto> UpdateAsync(int id, CreateTipoReunionDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
