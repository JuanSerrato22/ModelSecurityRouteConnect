using Business.Interfaces;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModuleController : ControllerBase, IModuleController
    {
        private readonly IModuleService _moduleService;

        public ModuleController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var modules = await _moduleService.GetAllAsync();
            return Ok(modules);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var module = await _moduleService.GetByIdAsync(id);
            if (module == null) return NotFound();
            return Ok(module);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ModuleDTO moduleDto)
        {
            var created = await _moduleService.CreateAsync(moduleDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ModuleDTO moduleDto)
        {
            var updated = await _moduleService.UpdateAsync(id, moduleDto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _moduleService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}