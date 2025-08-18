using SIGECAP2.API.Models;

namespace SIGECAP2.API.Repositories
{
    public interface IProfesionRepository
    {
        Task<IEnumerable<Profesion>> GetAllAsync();
        Task<Profesion?> GetByIdAsync(int id);
        Task<Profesion> AddAsync(Profesion profesion);
        Task<Profesion> UpdateAsync(Profesion profesion);
        Task<bool> DeleteAsync(int id);
    }
}

