using AutoMapper;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;

namespace SIGECAP2.API.Mappings
{
    public class ProfesionProfile : Profile
    {
        public ProfesionProfile()
        {
            CreateMap<Profesion, ProfesionDTO>().ReverseMap();
            CreateMap<CrearProfesionDTO, Profesion>();
        }
    }
}
