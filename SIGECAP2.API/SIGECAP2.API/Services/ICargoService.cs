using SIGECAP2.API.Dtos;
using SIGECAP2.API.DTOs;

namespace SIGECAP2.API.Services
{
    public interface ICargoService
    {
        Task<IEnumerable<CargoDto>> GetAllAsync();
        Task<CargoDto?> GetByIdAsync(int id);
        Task AddAsync(CargoDto cargoDto);
        Task UpdateAsync(CargoDto cargoDto);
        Task DeleteAsync(int id);
    }
}
