using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Entity.DTO;
using System.Threading.Tasks;

namespace Web.Controllers.Interface
{
    public interface IPaymentController
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetById(int id);
        Task<IActionResult> Create(PaymentDTO paymentDto);
        Task<IActionResult> Update(int id, PaymentDTO paymentDto);
        Task<IActionResult> Delete(int id);
    }
}