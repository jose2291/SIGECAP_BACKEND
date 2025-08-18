using SIGECAP2.API.DTOs;

namespace SIGECAP2.API.Services
{
    public interface IRolService
    {
        Task<IEnumerable<RolDto>> GetAllAsync();
        Task<RolDto?> GetByIdAsync(int id);
        Task<RolDto> AddAsync(RolDto dto);
        Task<RolDto> UpdateAsync(RolDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
