using AutoMapper;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;
using SIGECAP2.API.Repositories;

namespace SIGECAP2.API.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IDepartamentoRepository _repository;
        private readonly IMapper _mapper;

        public DepartamentoService(IDepartamentoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartamentoDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<DepartamentoDto>>(await _repository.GetAllAsync());

        public async Task<DepartamentoDto> GetByIdAsync(int id) =>
            _mapper.Map<DepartamentoDto>(await _repository.GetByIdAsync(id));

        public async Task AddAsync(DepartamentoDto dto) =>
            await _repository.AddAsync(_mapper.Map<Departamento>(dto));

        public async Task UpdateAsync(DepartamentoDto dto) =>
            await _repository.UpdateAsync(_mapper.Map<Departamento>(dto));

        public async Task DeleteAsync(int id) =>
            await _repository.DeleteAsync(id);
    }
}
