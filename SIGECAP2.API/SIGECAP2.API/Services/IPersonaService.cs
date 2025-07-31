using SIGECAP2.API.DTOs;
using SIGECAP2.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPersonaService
{
    Task CrearPersonaAsync(PersonaDTO personaDto);
    Task<List<PersonaDTO>> ObtenerPersonasAsync();

    // ✅ Nuevo método
    Task<Persona> BuscarPorNumeroOIdentidadAsync(string numeroEmpleado, string dni);
    Task<PersonaDTO?> BuscarPorCriterioAsync(string criterio);

}
