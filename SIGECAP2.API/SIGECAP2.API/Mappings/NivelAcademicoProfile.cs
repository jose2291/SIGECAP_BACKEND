using AutoMapper;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;

namespace SIGECAP2.API.Mappings
{
    public class NivelAcademicoProfile : Profile
    {
        public NivelAcademicoProfile()
        {
            CreateMap<NivelAcademico, NivelAcademicoDTO>().ReverseMap();
            CreateMap<CrearNivelAcademicoDTO, NivelAcademico>();
        }
    }
}
