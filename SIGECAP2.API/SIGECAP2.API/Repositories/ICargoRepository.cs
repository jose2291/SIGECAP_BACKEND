using SIGECAP2.API.Models;

namespace SIGECAP2.API.Repositories
{
    public interface ICargoRepository
    {
        Task<IEnumerable<Cargo>> GetAllAsync();
        Task<Cargo?> GetByIdAsync(int id);
        Task AddAsync(Cargo cargo);
        Task UpdateAsync(Cargo cargo);
        Task DeleteAsync(int id);
    }
}
