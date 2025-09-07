using Business.Interfaces;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase, IActivityController
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var activitys = await _activityService.GetAllAsync();
            return Ok(activitys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var activity = await _activityService.GetByIdAsync(id);
            if (activity == null) return NotFound();
            return Ok(activity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ActivityDTO activityDto)
        {
            var created = await _activityService.CreateAsync(activityDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ActivityDTO activityDto)
        {
            var updated = await _activityService.UpdateAsync(id, activityDto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _activityService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}