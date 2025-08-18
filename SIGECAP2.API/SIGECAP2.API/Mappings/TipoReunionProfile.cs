using AutoMapper;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;

namespace SIGECAP2.API.Mappings
{
    public class TipoReunionProfile : Profile
    {
        public TipoReunionProfile()
        {
            CreateMap<TipoReunion, TipoReunionDto>();
            CreateMap<CreateTipoReunionDto, TipoReunion>();
        }
    }
}
