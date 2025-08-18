using SIGECAP2.API.DTOs;

namespace SIGECAP2.API.Services
{
    public interface IRecursoService
    {
        Task<IEnumerable<RecursoDto>> GetAllAsync();
        Task<RecursoDto?> GetByIdAsync(int id);
        Task<RecursoDto> AddAsync(CreateRecursoDto dto);
        Task<RecursoDto?> UpdateAsync(int id, CreateRecursoDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
