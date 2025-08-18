using SIGECAP2.API.DTOs;

namespace SIGECAP2.API.Services
{
    public interface IInstitucionService
    {
        Task<IEnumerable<InstitucionDTO>> GetAllAsync();
        Task<InstitucionDTO> GetByIdAsync(int id);
        Task AddAsync(InstitucionDTO institucionDto);
        Task UpdateAsync(InstitucionDTO institucionDto);
        Task DeleteAsync(int id);
    }
}
