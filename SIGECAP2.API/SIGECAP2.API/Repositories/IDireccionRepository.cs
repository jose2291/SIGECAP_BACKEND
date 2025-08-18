using SIGECAP2.API.Models;

namespace SIGECAP2.API.Repositories
{
    public interface IDireccionRepository
    {
        Task<IEnumerable<Direccion>> GetAllAsync();
        Task<Direccion?> GetByIdAsync(int id);
        Task AddAsync(Direccion direccion);
        Task UpdateAsync(Direccion direccion);
        Task DeleteAsync(int id);
    }
}
