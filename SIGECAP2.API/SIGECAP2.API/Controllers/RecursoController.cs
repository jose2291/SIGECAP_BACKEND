using Microsoft.AspNetCore.Mvc;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Services;

namespace SIGECAP2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecursoController : ControllerBase
    {
        private readonly IRecursoService _service;

        public RecursoController(IRecursoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecursoDto>>> GetAll()
        {
            var lista = await _service.GetAllAsync();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecursoDto>> GetById(int id)
        {
            var recurso = await _service.GetByIdAsync(id);
            if (recurso == null) return NotFound();
            return Ok(recurso);
        }

        [HttpPost]
        public async Task<ActionResult<RecursoDto>> Create(CreateRecursoDto dto)
        {
            var creado = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RecursoDto>> Update(int id, CreateRecursoDto dto)
        {
            var actualizado = await _service.UpdateAsync(id, dto);
            if (actualizado == null) return NotFound();
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
