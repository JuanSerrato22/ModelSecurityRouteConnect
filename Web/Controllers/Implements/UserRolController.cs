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
    public class UserRolController : ControllerBase, IUserRolController
    {
        private readonly IUserRolService _userRolService;

        public UserRolController(IUserRolService userRolService)
        {
            _userRolService = userRolService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userRols = await _userRolService.GetAllAsync();
            return Ok(userRols);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userRol = await _userRolService.GetByIdAsync(id);
            if (userRol == null) return NotFound();
            return Ok(userRol);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRolDTO userRolDto)
        {
            var created = await _userRolService.CreateAsync(userRolDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserRolDTO userRolDto)
        {
            var updated = await _userRolService.UpdateAsync(id, userRolDto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePartial(int id, [FromBody] UserRolDTO userRolDto)
        {
            if (userRolDto == null) return BadRequest();

            // Obtener la userRola existente
            var userRol = await _userRolService.GetByIdAsync(id);
            if (userRol == null) return NotFound();

            // Actualizar solo los campos que vienen distintos de null
            var updatedUserRol = new UserRolDTO
            {
                Id = userRol.Id,
                Name = userRolDto.Name ?? userRol.Name
            };

            var updated = await _userRolService.UpdateAsync(id, updatedUserRol);
            return Ok(updated);
        }


        [HttpDelete("soft/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var deleted = await _userRolService.SoftDeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _userRolService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}