using AutoMapper;
using SIGECAP2.API.Dtos;
using SIGECAP2.API.Models;

namespace SIGECAP2.API.Mappings
{
    public class CargoProfile : Profile
    {
        public CargoProfile()
        {
            CreateMap<Cargo, CargoDto>().ReverseMap();
        }
    }
}
