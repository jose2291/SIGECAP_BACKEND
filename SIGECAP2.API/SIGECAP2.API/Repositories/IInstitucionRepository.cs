using SIGECAP2.API.Models;

namespace SIGECAP2.API.Repositories
{
    public interface IInstitucionRepository
    {
        Task<IEnumerable<Institucion>> GetAllAsync();
        Task<Institucion> GetByIdAsync(int id);
        Task AddAsync(Institucion institucion);
        Task UpdateAsync(Institucion institucion);
        Task DeleteAsync(int id);
    }
}
