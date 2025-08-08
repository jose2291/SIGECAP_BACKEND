using AutoMapper;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;

namespace SIGECAP2.API.Mappings
{
    public class ReservaProfile : Profile
    {
        public ReservaProfile()
        {
            CreateMap<ReservaDTO, Reserva>()
                .ForMember(dest => dest.Fechas, opt => opt.Ignore())
                .ForMember(dest => dest.Accesorios, opt => opt.Ignore());

            CreateMap<Reserva, ReservaDTO>()
                .ForMember(dest => dest.Fechas, opt => opt.MapFrom(src => src.Fechas.Select(f => f.Fecha)))
                .ForMember(dest => dest.Accesorios, opt => opt.MapFrom(src => src.Accesorios.Select(a => a.Accesorio)));
        }
    }
}
