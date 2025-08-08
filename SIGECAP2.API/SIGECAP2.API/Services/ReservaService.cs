using AutoMapper;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;
using SIGECAP2.API.Repositories;

namespace SIGECAP2.API.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _repository;
        private readonly IMapper _mapper;

        public ReservaService(IReservaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CrearReservaAsync(ReservaDTO dto)
        {
            var reserva = _mapper.Map<Reserva>(dto);

            if (dto.Recursiva && dto.Fechas != null)
            {
                reserva.Fechas = dto.Fechas.Select(f => new FechaReserva { Fecha = f }).ToList();
            }
            else if (!dto.Recursiva && dto.Fechas != null && dto.Fechas.Any())
            {
                // ✅ Aquí se asigna correctamente FechaUnica si no es recursiva
                reserva.FechaUnica = dto.Fechas.First();
            }

            reserva.Accesorios = dto.Accesorios?.Select(a => new AccesorioReserva { Accesorio = a }).ToList();

            await _repository.CrearReservaAsync(reserva);
        }

        public async Task<List<ReservaDTO>> ObtenerReservasAsync()
        {
            var reservas = await _repository.ObtenerReservasAsync();
            return _mapper.Map<List<ReservaDTO>>(reservas);
        }
    }
}
