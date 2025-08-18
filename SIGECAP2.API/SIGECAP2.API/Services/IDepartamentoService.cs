using SIGECAP2.API.DTOs;

namespace SIGECAP2.API.Services
{
    public interface IDepartamentoService
    {
        Task<IEnumerable<DepartamentoDto>> GetAllAsync();
        Task<DepartamentoDto> GetByIdAsync(int id);
        Task AddAsync(DepartamentoDto dto);
        Task UpdateAsync(DepartamentoDto dto);
        Task DeleteAsync(int id);
    }
}
