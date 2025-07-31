using AutoMapper;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;

namespace SIGECAP2.API.Mappings
{
    public class PersonaProfile : Profile
    {
        public PersonaProfile()
        {
            CreateMap<Persona, PersonaDTO>();         // ← falta este
            CreateMap<PersonaDTO, Persona>();         // ← ya lo tenías
        }
    }
}
