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
    public class RolFormPermissionController : ControllerBase, IRolFormPermissionController
    {
        private readonly IRolFormPermissionService _rolFormPermissionService;

        public RolFormPermissionController(IRolFormPermissionService rolFormPermissionService)
        {
            _rolFormPermissionService = rolFormPermissionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rolFormPermissions = await _rolFormPermissionService.GetAllAsync();
            return Ok(rolFormPermissions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rolFormPermission = await _rolFormPermissionService.GetByIdAsync(id);
            if (rolFormPermission == null) return NotFound();
            return Ok(rolFormPermission);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RolFormPermissionDTO rolFormPermissionDto)
        {
            var created = await _rolFormPermissionService.CreateAsync(rolFormPermissionDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RolFormPermissionDTO rolFormPermissionDto)
        {
            var updated = await _rolFormPermissionService.UpdateAsync(id, rolFormPermissionDto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePartial(int id, [FromBody] RolFormPermissionDTO rolFormPermissionDto)
        {
            if (rolFormPermissionDto == null) return BadRequest();

            // Obtener la rolFormPermissiona existente
            var rolFormPermission = await _rolFormPermissionService.GetByIdAsync(id);
            if (rolFormPermission == null) return NotFound();

            // Actualizar solo los campos que vienen distintos de null
            var updatedRolFormPermission = new RolFormPermissionDTO
            {
                Id = rolFormPermission.Id,
                Name = rolFormPermissionDto.Name ?? rolFormPermission.Name
            };

            var updated = await _rolFormPermissionService.UpdateAsync(id, updatedRolFormPermission);
            return Ok(updated);
        }


        [HttpDelete("soft/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var deleted = await _rolFormPermissionService.SoftDeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _rolFormPermissionService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}