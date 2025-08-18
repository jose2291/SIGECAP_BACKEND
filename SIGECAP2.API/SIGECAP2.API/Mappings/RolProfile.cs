using AutoMapper;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;

namespace SIGECAP2.API.Mappings
{
    public class RolProfile : Profile
    {
        public RolProfile()
        {
            CreateMap<Rol, RolDto>().ReverseMap();
        }
    }
}
