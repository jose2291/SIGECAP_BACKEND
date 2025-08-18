using Microsoft.AspNetCore.Mvc;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Services;

namespace SIGECAP2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalonController : ControllerBase
    {
        private readonly ISalonService _service;

        public SalonController(ISalonService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalonDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalonDto>> GetById(int id)
        {
            var salon = await _service.GetByIdAsync(id);
            if (salon == null) return NotFound();
            return Ok(salon);
        }

        [HttpPost]
        public async Task<ActionResult<SalonDto>> Create(SalonDto salonDto)
        {
            var created = await _service.AddAsync(salonDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SalonDto>> Update(int id, SalonDto salonDto)
        {
            if (id != salonDto.Id) return BadRequest();

            var updated = await _service.UpdateAsync(salonDto);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
