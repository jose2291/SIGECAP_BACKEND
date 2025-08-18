using Microsoft.AspNetCore.Mvc;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Services;

namespace SIGECAP2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesionController : ControllerBase
    {
        private readonly IProfesionService _service;

        public ProfesionController(IProfesionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfesionDTO>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProfesionDTO>> GetById(int id)
        {
            var profesion = await _service.GetByIdAsync(id);
            if (profesion == null) return NotFound();
            return Ok(profesion);
        }

        [HttpPost]
        public async Task<ActionResult<ProfesionDTO>> Add(CrearProfesionDTO dto)
        {
            var nuevo = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, nuevo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProfesionDTO>> Update(int id, ProfesionDTO dto)
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
