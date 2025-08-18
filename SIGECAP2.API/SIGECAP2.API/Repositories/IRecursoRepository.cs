using SIGECAP2.API.Models;

namespace SIGECAP2.API.Repositories
{
    public interface IRecursoRepository
    {
        Task<IEnumerable<Recurso>> GetAllAsync();
        Task<Recurso?> GetByIdAsync(int id);
        Task<Recurso> AddAsync(Recurso recurso);
        Task<Recurso?> UpdateAsync(Recurso recurso);
        Task<bool> DeleteAsync(int id);
    }
}
