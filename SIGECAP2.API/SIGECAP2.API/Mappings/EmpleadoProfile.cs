using AutoMapper;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;

public class EmpleadoProfile : Profile
{
    public EmpleadoProfile()
    {
        CreateMap<EmpleadoDTO, Empleado>();

        CreateMap<Empleado, EmpleadoDTO>()
            .ForMember(dest => dest.DNI, opt => opt.MapFrom(src => src.DNI ?? ""))
            .ForMember(dest => dest.NombreCompleto, opt => opt.MapFrom(src => src.NombreCompleto ?? ""))
            .ForMember(dest => dest.Correo, opt => opt.MapFrom(src => src.Correo ?? ""))
            .ForMember(dest => dest.Departamento, opt => opt.MapFrom(src => src.Departamento ?? ""))
            .ForMember(dest => dest.Cargo, opt => opt.MapFrom(src => src.Cargo ?? ""))
            .ForMember(dest => dest.Estado, opt => opt.MapFrom(src =>
                string.IsNullOrWhiteSpace(src.Estado) ? "No especificado" : src.Estado));
    }
}
