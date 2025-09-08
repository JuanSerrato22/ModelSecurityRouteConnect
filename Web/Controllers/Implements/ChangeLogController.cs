using Business.Interfaces;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChangeLogController : ControllerBase, IChangeLogController
    {
        private readonly IChangeLogService _changeLogService;

        public ChangeLogController(IChangeLogService changeLogService)
        {
            _changeLogService = changeLogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var changeLogs = await _changeLogService.GetAllAsync();
            return Ok(changeLogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var changeLog = await _changeLogService.GetByIdAsync(id);
            if (changeLog == null) return NotFound();
            return Ok(changeLog);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ChangeLogDTO changeLogDto)
        {
            var created = await _changeLogService.CreateAsync(changeLogDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ChangeLogDTO changeLogDto)
        {
            var updated = await _changeLogService.UpdateAsync(id, changeLogDto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _changeLogService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}