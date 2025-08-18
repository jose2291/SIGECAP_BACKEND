using SIGECAP2.API.Models;

namespace SIGECAP2.API.Repositories
{
    public interface INivelAcademicoRepository
    {
        Task<IEnumerable<NivelAcademico>> GetAllAsync();
        Task<NivelAcademico?> GetByIdAsync(int id);
        Task<NivelAcademico> AddAsync(NivelAcademico nivel);
        Task<NivelAcademico> UpdateAsync(NivelAcademico nivel);
        Task<bool> DeleteAsync(int id);
    }
}
