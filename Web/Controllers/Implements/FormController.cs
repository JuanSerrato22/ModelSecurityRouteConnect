using Business.Interfaces;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : ControllerBase, IFormController
    {
        private readonly IFormService _formService;

        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var forms = await _formService.GetAllAsync();
            return Ok(forms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var form = await _formService.GetByIdAsync(id);
            if (form == null) return NotFound();
            return Ok(form);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FormDTO formDto)
        {
            var created = await _formService.CreateAsync(formDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FormDTO formDto)
        {
            var updated = await _formService.UpdateAsync(id, formDto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _formService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}