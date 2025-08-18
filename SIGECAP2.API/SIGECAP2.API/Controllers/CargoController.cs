using Microsoft.AspNetCore.Mvc;
using SIGECAP2.API.Dtos;
using SIGECAP2.API.DTOs;
using SIGECAP2.API.Services;

namespace SIGECAP2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _cargoService;

        public CargoController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CargoDto>>> GetAll()
        {
            var cargos = await _cargoService.GetAllAsync();
            return Ok(cargos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CargoDto>> GetById(int id)
        {
            var cargo = await _cargoService.GetByIdAsync(id);
            if (cargo == null) return NotFound();
            return Ok(cargo);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CargoDto cargoDto)
        {
            await _cargoService.AddAsync(cargoDto);
            return CreatedAtAction(nameof(GetById), new { id = cargoDto.Id }, cargoDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CargoDto cargoDto)
        {
            if (id != cargoDto.Id) return BadRequest();
            await _cargoService.UpdateAsync(cargoDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _cargoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
