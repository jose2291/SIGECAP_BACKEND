using SIGECAP2.API.DTOs;

namespace SIGECAP2.API.Services
{
    public interface IDireccionService
    {
        Task<IEnumerable<DireccionDTO>> GetAllAsync();
        Task<DireccionDTO?> GetByIdAsync(int id);
        Task<DireccionDTO> AddAsync(DireccionDTO dto);
        Task<DireccionDTO?> UpdateAsync(int id, DireccionDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}

