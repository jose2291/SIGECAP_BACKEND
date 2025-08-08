using Microsoft.AspNetCore.Mvc;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Services;

namespace SIGECAP2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _service;

        public ReservaController(IReservaService service)
        {
            _service = service;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear([FromBody] ReservaDTO dto)
        {
            try
            {
                await _service.CrearReservaAsync(dto);
                return Ok(new { mensaje = "✅ Reserva creada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "❌ Error al crear reserva", detalle = ex.Message });
            }
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Obtener()
        {
            var lista = await _service.ObtenerReservasAsync();
            return Ok(lista);
        }
    }
}
