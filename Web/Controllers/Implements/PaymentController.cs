using Business.Implements;
using Business.Interfaces;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase, IPaymentController
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var payments = await _paymentService.GetAllAsync();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var payment = await _paymentService.GetByIdAsync(id);
            if (payment == null) return NotFound();
            return Ok(payment);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PaymentDTO paymentDto)
        {
            var created = await _paymentService.CreateAsync(paymentDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PaymentDTO paymentDto)
        {
            var updated = await _paymentService.UpdateAsync(id, paymentDto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePartial(int id, [FromBody] PaymentDTO paymentDto)
        {
            if (paymentDto == null) return BadRequest();

            // Obtener la paymenta existente
            var payment = await _paymentService.GetByIdAsync(id);
            if (payment == null) return NotFound();

            // Actualizar solo los campos que vienen distintos de null
            var updatedPayment = new PaymentDTO
            {
                Id = payment.Id,
                PaymentMethod = paymentDto.PaymentMethod ?? payment.PaymentMethod,
                Amount = paymentDto.Amount != 0 ? paymentDto.Amount : payment.Amount,
                Activity = paymentDto.Activity ?? payment.Activity
            };

            var updated = await _paymentService.UpdateAsync(id, updatedPayment);
            return Ok(updated);
        }


        [HttpDelete("soft/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var deleted = await _paymentService.SoftDeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _paymentService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}