using Microsoft.AspNetCore.Mvc;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Services;

namespace SIGECAP2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstitucionController : ControllerBase
    {
        private readonly IInstitucionService _service;

        public InstitucionController(IInstitucionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstitucionDTO>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InstitucionDTO>> GetById(int id)
        {
            var institucion = await _service.GetByIdAsync(id);
            if (institucion == null) return NotFound();
            return Ok(institucion);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] InstitucionDTO institucionDto)
        {
            await _service.AddAsync(institucionDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] InstitucionDTO institucionDto)
        {
            if (id != institucionDto.Id) return BadRequest();
            await _service.UpdateAsync(institucionDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
