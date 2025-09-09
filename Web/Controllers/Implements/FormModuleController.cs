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
    public class FormModuleController : ControllerBase, IFormModuleController
    {
        private readonly IFormModuleService _formModuleService;

        public FormModuleController(IFormModuleService formModuleService)
        {
            _formModuleService = formModuleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var formModules = await _formModuleService.GetAllAsync();
            return Ok(formModules);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var formModule = await _formModuleService.GetByIdAsync(id);
            if (formModule == null) return NotFound();
            return Ok(formModule);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FormModuleDTO formModuleDto)
        {
            var created = await _formModuleService.CreateAsync(formModuleDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FormModuleDTO formModuleDto)
        {
            var updated = await _formModuleService.UpdateAsync(id, formModuleDto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePartial(int id, [FromBody] FormModuleDTO formModuleDto)
        {
            if (formModuleDto == null) return BadRequest();

            // Obtener la formModulea existente
            var formModule = await _formModuleService.GetByIdAsync(id);
            if (formModule == null) return NotFound();

            // Actualizar solo los campos que vienen distintos de null
            var updatedFormModule = new FormModuleDTO
            {
                Id = formModule.Id,
                Name = formModuleDto.Name ?? formModule.Name
            };

            var updated = await _formModuleService.UpdateAsync(id, updatedFormModule);
            return Ok(updated);
        }


        [HttpDelete("soft/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var deleted = await _formModuleService.SoftDeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _formModuleService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}