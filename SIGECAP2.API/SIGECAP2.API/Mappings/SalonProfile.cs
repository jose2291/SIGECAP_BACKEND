using AutoMapper;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;

namespace SIGECAP2.API.Mappings
{
    public class SalonProfile : Profile
    {
        public SalonProfile()
        {
            CreateMap<Salon, SalonDto>().ReverseMap();
        }
    }
}

