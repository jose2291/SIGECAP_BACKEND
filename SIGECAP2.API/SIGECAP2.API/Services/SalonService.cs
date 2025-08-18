using AutoMapper;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;
using SIGECAP2.API.Repositories;

namespace SIGECAP2.API.Services
{
    public class SalonService : ISalonService
    {
        private readonly ISalonRepository _repository;
        private readonly IMapper _mapper;

        public SalonService(ISalonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SalonDto>> GetAllAsync()
        {
            var salones = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<SalonDto>>(salones);
        }

        public async Task<SalonDto> GetByIdAsync(int id)
        {
            var salon = await _repository.GetByIdAsync(id);
            return _mapper.Map<SalonDto>(salon);
        }

        public async Task<SalonDto> AddAsync(SalonDto salonDto)
        {
            var salon = _mapper.Map<Salon>(salonDto);
            var result = await _repository.AddAsync(salon);
            return _mapper.Map<SalonDto>(result);
        }

        public async Task<SalonDto> UpdateAsync(SalonDto salonDto)
        {
            var salon = _mapper.Map<Salon>(salonDto);
            var result = await _repository.UpdateAsync(salon);
            return _mapper.Map<SalonDto>(result);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
