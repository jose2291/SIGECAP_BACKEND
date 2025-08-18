using SIGECAP2.API.DTOs;

namespace SIGECAP2.API.Services
{
    public interface INivelAcademicoService
    {
        Task<IEnumerable<NivelAcademicoDTO>> GetAllAsync();
        Task<NivelAcademicoDTO?> GetByIdAsync(int id);
        Task<NivelAcademicoDTO> AddAsync(CrearNivelAcademicoDTO dto);
        Task<NivelAcademicoDTO> UpdateAsync(NivelAcademicoDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
