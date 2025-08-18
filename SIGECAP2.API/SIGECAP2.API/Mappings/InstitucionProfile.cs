using AutoMapper;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;

namespace SIGECAP2.API.Mappings
{
    public class InstitucionProfile : Profile
    {
        public InstitucionProfile()
        {
            CreateMap<Institucion, InstitucionDTO>().ReverseMap();
        }
    }
}
