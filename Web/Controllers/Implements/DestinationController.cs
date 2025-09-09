using Business.Implements;
using Business.Interfaces;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinationController : ControllerBase, IDestinationController
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var destinations = await _destinationService.GetAllAsync();
            return Ok(destinations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var destination = await _destinationService.GetByIdAsync(id);
            if (destination == null) return NotFound();
            return Ok(destination);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DestinationDTO destinationDto)
        {
            var created = await _destinationService.CreateAsync(destinationDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DestinationDTO destinationDto)
        {
            var updated = await _destinationService.UpdateAsync(id, destinationDto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePartial(int id, [FromBody] DestinationDTO destinationDto)
        {
            if (destinationDto == null) return BadRequest();

            // Obtener la destinationa existente
            var destination = await _destinationService.GetByIdAsync(id);
            if (destination == null) return NotFound();

            // Actualizar solo los campos que vienen distintos de null
            var updatedDestination = new DestinationDTO
            {
                Id = destination.Id,
                Name = destinationDto.Name ?? destination.Name,
                Description = destinationDto.Description ?? destination.Description,
                Country = destinationDto.Country ?? destination.Country,
                Region = destinationDto.Region ?? destination.Region,
                Latitude = destinationDto.Latitude ?? destination.Latitude,
                Longitude = destinationDto.Longitude ?? destination.Longitude

            };

            var updated = await _destinationService.UpdateAsync(id, updatedDestination);
            return Ok(updated);
        }


        [HttpDelete("soft/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var deleted = await _destinationService.SoftDeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _destinationService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}