using Microsoft.AspNetCore.Mvc;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGECAP2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _service;

        public PersonaController(IPersonaService service)
        {
            _service = service;
        }

        // POST: api/persona
        [HttpPost]
        public async Task<IActionResult> CrearPersona([FromBody] PersonaDTO personaDto)
        {
            try
            {
                await _service.CrearPersonaAsync(personaDto);
                return Ok(new { mensaje = "✅ Persona registrada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = "❌ Error interno al registrar persona",
                    mensaje = ex.Message,
                    inner = ex.InnerException?.Message,
                    stack = ex.StackTrace
                });
            }
        }

        // GET: api/persona
        [HttpGet]
        public async Task<IActionResult> ObtenerPersonas()
        {
            try
            {
                var personas = await _service.ObtenerPersonasAsync();

                if (personas == null)
                {
                    return NotFound(new
                    {
                        mensaje = "⚠️ No se encontraron personas registradas."
                    });
                }

                return Ok(personas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = "❌ Error al obtener personas",
                    mensaje = ex.Message,
                    inner = ex.InnerException?.Message,
                    stack = ex.StackTrace
                });
            }
        }

        // ✅ GET: api/persona/buscar?criterio=EMP001 o 0801199912345
        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarPorCriterio([FromQuery] string criterio)
        {
            try
            {
                var persona = await _service.BuscarPorCriterioAsync(criterio);
                if (persona == null)
                {
                    return NotFound(new { mensaje = "❌ Persona no encontrada" });
                }

                return Ok(persona);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = "❌ Error al buscar persona",
                    mensaje = ex.Message,
                    inner = ex.InnerException?.Message,
                    stack = ex.StackTrace
                });
            }
        }
    }
}
