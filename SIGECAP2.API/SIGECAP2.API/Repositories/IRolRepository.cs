using SIGECAP2.API.Models;

namespace SIGECAP2.API.Repositories
{
    public interface IRolRepository
    {
        Task<IEnumerable<Rol>> GetAllAsync();
        Task<Rol?> GetByIdAsync(int id);
        Task<Rol> AddAsync(Rol rol);
        Task<Rol> UpdateAsync(Rol rol);
        Task<bool> DeleteAsync(int id);
    }
}
