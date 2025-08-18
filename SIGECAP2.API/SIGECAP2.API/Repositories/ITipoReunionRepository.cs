using SIGECAP2.API.Models;

namespace SIGECAP2.API.Repositories
{
    public interface ITipoReunionRepository
    {
        Task<IEnumerable<TipoReunion>> GetAllAsync();
        Task<TipoReunion?> GetByIdAsync(int id);
        Task<TipoReunion> AddAsync(TipoReunion tipoReunion);
        Task<TipoReunion> UpdateAsync(TipoReunion tipoReunion);
        Task<bool> DeleteAsync(int id);
    }
}
