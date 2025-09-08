using Business.Interfaces;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinationActivityController : ControllerBase, IDestinationActivityController
    {
        private readonly IDestinationActivityService _destinationActivityService;

        public DestinationActivityController(IDestinationActivityService destinationActivityService)
        {
            _destinationActivityService = destinationActivityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var destinationActivitys = await _destinationActivityService.GetAllAsync();
            return Ok(destinationActivitys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var destinationActivity = await _destinationActivityService.GetByIdAsync(id);
            if (destinationActivity == null) return NotFound();
            return Ok(destinationActivity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DestinationActivityDTO destinationActivityDto)
        {
            var created = await _destinationActivityService.CreateAsync(destinationActivityDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _destinationActivityService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}