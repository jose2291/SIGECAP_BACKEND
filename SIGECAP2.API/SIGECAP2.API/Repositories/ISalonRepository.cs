using SIGECAP2.API.Models;

namespace SIGECAP2.API.Repositories
{
    public interface ISalonRepository
    {
        Task<IEnumerable<Salon>> GetAllAsync();
        Task<Salon> GetByIdAsync(int id);
        Task<Salon> AddAsync(Salon salon);
        Task<Salon> UpdateAsync(Salon salon);
        Task<bool> DeleteAsync(int id);
    }
}
