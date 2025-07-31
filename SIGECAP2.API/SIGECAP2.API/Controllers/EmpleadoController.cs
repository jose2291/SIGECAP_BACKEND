using Microsoft.AspNetCore.Mvc;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Services;
using System;
using System.Threading.Tasks;

namespace SIGECAP2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly IPersonaService _personaService;

        public EmpleadoController(IEmpleadoService empleadoService, IPersonaService personaService)
        {
            _empleadoService = empleadoService;
            _personaService = personaService;
        }

        // ✅ POST: api/empleado/registrar?criterio=EMP001 o ?criterio=0801199912345
        [HttpPost("registrar")]
        public async Task<IActionResult> CrearEmpleado([FromQuery] string criterio)
        {
            try
            {
                var persona = await _personaService.BuscarPorCriterioAsync(criterio);
                if (persona == null)
                {
                    return NotFound(new { mensaje = "❌ Persona no encontrada" });
                }

                var nuevoEmpleado = new EmpleadoDTO
                {
                    NumeroEmpleado = persona.NumeroEmpleado,
                    DNI = persona.DNI,
                    NombreCompleto = $"{persona.PrimerNombre} {persona.SegundoNombre} {persona.PrimerApellido} {persona.SegundoApellido}".Trim(),
                    Correo = persona.Correo,
                    Departamento = persona.DireccionPuesto,
                    Cargo = persona.Cargo,
                    Estado = persona.Estado,
                    Activo = persona.Estado == "Activo"
                };

                await _empleadoService.CrearEmpleadoAsync(nuevoEmpleado);

                return Ok(new { mensaje = "✅ Empleado registrado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = "❌ Error al registrar empleado",
                    mensaje = ex.Message,
                    inner = ex.InnerException?.Message
                });
            }
        }

        // ✅ GET: api/empleado/listar
        [HttpGet("listar")]
        public async Task<IActionResult> ObtenerEmpleados()
        {
            try
            {
                var empleados = await _empleadoService.ObtenerEmpleadosAsync();
                return Ok(empleados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = "❌ Error al obtener empleados",
                    mensaje = ex.Message,
                    inner = ex.InnerException?.Message
                });
            }
        }
    }
}
