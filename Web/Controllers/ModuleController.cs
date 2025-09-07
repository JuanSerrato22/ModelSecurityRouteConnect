using Business.Interfaces;
using Entity.Dtos.ClientDTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase, IClientesController
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteService.GetAllAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClientDto clienteDto)
        {
            var created = await _clienteService.CreateAsync(clienteDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClientDto clienteDto)
        {
            var updated = await _clienteService.UpdateAsync(id, clienteDto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _clienteService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}