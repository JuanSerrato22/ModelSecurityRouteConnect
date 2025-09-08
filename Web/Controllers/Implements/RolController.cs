using Business.Interfaces;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase, IRolController
    {
        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rols = await _rolService.GetAllAsync();
            return Ok(rols);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rol = await _rolService.GetByIdAsync(id);
            if (rol == null) return NotFound();
            return Ok(rol);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RolDTO rolDto)
        {
            var created = await _rolService.CreateAsync(rolDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RolDTO rolDto)
        {
            var updated = await _rolService.UpdateAsync(id, rolDto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _rolService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}