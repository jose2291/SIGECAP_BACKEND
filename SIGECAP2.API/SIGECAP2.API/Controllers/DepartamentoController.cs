using Microsoft.AspNetCore.Mvc;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Services;

namespace SIGECAP2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService _service;

        public DepartamentoController(IDepartamentoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DepartamentoDto dto)
        {
            await _service.AddAsync(dto);
            return Ok(new { message = "Departamento creado exitosamente" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DepartamentoDto dto)
        {
            if (id != dto.Id) return BadRequest();
            await _service.UpdateAsync(dto);
            return Ok(new { message = "Departamento actualizado exitosamente" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok(new { message = "Departamento eliminado exitosamente" });
        }
    }
}
