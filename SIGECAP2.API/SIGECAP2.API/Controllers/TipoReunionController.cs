using Microsoft.AspNetCore.Mvc;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Services;

namespace SIGECAP2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoReunionController : ControllerBase
    {
        private readonly ITipoReunionService _service;

        public TipoReunionController(ITipoReunionService service)
        {
            _service = service;
        }

        // GET: api/tiporeunion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoReunionDto>>> GetAll()
        {
            var lista = await _service.GetAllAsync();
            return Ok(lista);
        }

        // GET: api/tiporeunion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoReunionDto>> GetById(int id)
        {
            var tipoReunion = await _service.GetByIdAsync(id);
            if (tipoReunion == null)
                return NotFound(new { message = "Tipo de reunión no encontrado" });

            return Ok(tipoReunion);
        }

        // POST: api/tiporeunion
        [HttpPost]
        public async Task<ActionResult<TipoReunionDto>> Create(CreateTipoReunionDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Descripcion))
                return BadRequest(new { message = "La descripción es obligatoria" });

            var creado = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }

        // PUT: api/tiporeunion/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TipoReunionDto>> Update(int id, CreateTipoReunionDto dto)
        {
            try
            {
                var actualizado = await _service.UpdateAsync(id, dto);
                return Ok(actualizado);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE: api/tiporeunion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var eliminado = await _service.DeleteAsync(id);
            if (!eliminado)
                return NotFound(new { message = "Tipo de reunión no encontrado" });

            return NoContent();
        }
    }
}
