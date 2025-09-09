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
    public class RolPermissionController : ControllerBase, IRolPermissionController
    {
        private readonly IRolPermissionService _rolPermissionService;

        public RolPermissionController(IRolPermissionService rolPermissionService)
        {
            _rolPermissionService = rolPermissionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rolPermissions = await _rolPermissionService.GetAllAsync();
            return Ok(rolPermissions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rolPermission = await _rolPermissionService.GetByIdAsync(id);
            if (rolPermission == null) return NotFound();
            return Ok(rolPermission);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RolPermissionDTO rolPermissionDto)
        {
            var created = await _rolPermissionService.CreateAsync(rolPermissionDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RolPermissionDTO rolPermissionDto)
        {
            var updated = await _rolPermissionService.UpdateAsync(id, rolPermissionDto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePartial(int id, [FromBody] RolPermissionDTO rolPermissionDto)
        {
            if (rolPermissionDto == null) return BadRequest();

            // Obtener la rolPermissiona existente
            var rolPermission = await _rolPermissionService.GetByIdAsync(id);
            if (rolPermission == null) return NotFound();

            // Actualizar solo los campos que vienen distintos de null
            var updatedRolPermission = new RolPermissionDTO
            {
                Id = rolPermission.Id,
                Name = rolPermissionDto.Name ?? rolPermission.Name
            };

            var updated = await _rolPermissionService.UpdateAsync(id, updatedRolPermission);
            return Ok(updated);
        }


        [HttpDelete("soft/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var deleted = await _rolPermissionService.SoftDeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _rolPermissionService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}