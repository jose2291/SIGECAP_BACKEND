using SIGECAP2.API.Models;

namespace SIGECAP2.API.Repositories
{
    public interface IDepartamentoRepository
    {
        Task<IEnumerable<Departamento>> GetAllAsync();
        Task<Departamento> GetByIdAsync(int id);
        Task AddAsync(Departamento departamento);
        Task UpdateAsync(Departamento departamento);
        Task DeleteAsync(int id);
    }
}