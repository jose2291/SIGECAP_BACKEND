using SIGECAP2.API.DTOs;

namespace SIGECAP2.API.Services
{
    public interface ISalonService
    {
        Task<IEnumerable<SalonDto>> GetAllAsync();
        Task<SalonDto> GetByIdAsync(int id);
        Task<SalonDto> AddAsync(SalonDto salonDto);
        Task<SalonDto> UpdateAsync(SalonDto salonDto);
        Task<bool> DeleteAsync(int id);
    }
}
