using AutoMapper;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;

namespace SIGECAP2.API.Mappings
{
    public class DireccionProfile : Profile
    {
        public DireccionProfile()
        {
            CreateMap<Direccion, DireccionDTO>().ReverseMap();
        }
    }
}
