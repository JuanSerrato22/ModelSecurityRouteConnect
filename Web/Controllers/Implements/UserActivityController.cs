using Business.Interfaces;
using Entity.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserActivityController : ControllerBase, IUserActivityController
    {
        private readonly IUserActivityService _userActivityService;

        public UserActivityController(IUserActivityService userActivityService)
        {
            _userActivityService = userActivityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userActivitys = await _userActivityService.GetAllAsync();
            return Ok(userActivitys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userActivity = await _userActivityService.GetByIdAsync(id);
            if (userActivity == null) return NotFound();
            return Ok(userActivity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserActivityDTO userActivityDto)
        {
            var created = await _userActivityService.CreateAsync(userActivityDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserActivityDTO userActivityDto)
        {
            var updated = await _userActivityService.UpdateAsync(id, userActivityDto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePartial(int id, [FromBody] UserActivityDTO userActivityDto)
        {
            if (userActivityDto == null) return BadRequest();

            // Obtener la userActivitya existente
            var userActivity = await _userActivityService.GetByIdAsync(id);
            if (userActivity == null) return NotFound();

            // Actualizar solo los campos que vienen distintos de null
            var updatedUserActivity = new UserActivityDTO
            {
                Id = userActivity.Id,
                Name = userActivityDto.Name ?? userActivity.Name
            };

            var updated = await _userActivityService.UpdateAsync(id, updatedUserActivity);
            return Ok(updated);
        }


        [HttpDelete("soft/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var deleted = await _userActivityService.SoftDeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _userActivityService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}