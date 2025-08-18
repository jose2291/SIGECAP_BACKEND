using AutoMapper;
using SIGECAP2.API.Dtos;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;
using SIGECAP2.API.Repositories;

namespace SIGECAP2.API.Services
{
    public class CargoService : ICargoService
    {
        private readonly ICargoRepository _cargoRepository;
        private readonly IMapper _mapper;

        public CargoService(ICargoRepository cargoRepository, IMapper mapper)
        {
            _cargoRepository = cargoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CargoDto>> GetAllAsync()
        {
            var cargos = await _cargoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CargoDto>>(cargos);
        }

        public async Task<CargoDto?> GetByIdAsync(int id)
        {
            var cargo = await _cargoRepository.GetByIdAsync(id);
            return _mapper.Map<CargoDto?>(cargo);
        }

        public async Task AddAsync(CargoDto cargoDto)
        {
            var cargo = _mapper.Map<Cargo>(cargoDto);
            await _cargoRepository.AddAsync(cargo);
        }

        public async Task UpdateAsync(CargoDto cargoDto)
        {
            var cargo = _mapper.Map<Cargo>(cargoDto);
            await _cargoRepository.UpdateAsync(cargo);
        }

        public async Task DeleteAsync(int id)
        {
            await _cargoRepository.DeleteAsync(id);
        }
    }
}
