using SIGECAP2.API.DTOs;

namespace SIGECAP2.API.Services
{
    public interface IProfesionService
    {
        Task<IEnumerable<ProfesionDTO>> GetAllAsync();
        Task<ProfesionDTO?> GetByIdAsync(int id);
        Task<ProfesionDTO> AddAsync(CrearProfesionDTO dto);
        Task<ProfesionDTO> UpdateAsync(ProfesionDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
