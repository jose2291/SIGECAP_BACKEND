using Microsoft.AspNetCore.Mvc;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Services;

namespace SIGECAP2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NivelAcademicoController : ControllerBase
    {
        private readonly INivelAcademicoService _service;

        public NivelAcademicoController(INivelAcademicoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NivelAcademicoDTO>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NivelAcademicoDTO>> GetById(int id)
        {
            var nivel = await _service.GetByIdAsync(id);
            if (nivel == null) return NotFound();
            return Ok(nivel);
        }

        [HttpPost]
        public async Task<ActionResult<NivelAcademicoDTO>> Add(CrearNivelAcademicoDTO dto)
        {
            var nuevo = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, nuevo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<NivelAcademicoDTO>> Update(int id, NivelAcademicoDTO dto)
        {
            if (id != dto.Id) return BadRequest();
            var actualizado = await _service.UpdateAsync(dto);
            return Ok(actualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var eliminado = await _service.DeleteAsync(id);
            if (!eliminado) return NotFound();
            return NoContent();
        }
    }
}
