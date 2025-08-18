using AutoMapper;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;

namespace SIGECAP2.API.Mappings
{
    public class RecursoProfile : Profile
    {
        public RecursoProfile()
        {
            CreateMap<Recurso, RecursoDto>();
            CreateMap<CreateRecursoDto, Recurso>();
        }
    }
}
