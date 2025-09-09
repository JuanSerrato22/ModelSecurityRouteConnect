using Entity.DTO;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IPaymentService
    {
        Task<List<PaymentDTO>> GetAllAsync();
        Task<PaymentDTO> GetByIdAsync(int id);
        Task<PaymentDTO> CreateAsync(PaymentDTO paymentDto);
        Task<PaymentDTO> UpdateAsync(int id, PaymentDTO paymentDto);
        Task<PaymentDTO> UpdatePartialAsync(int id, JsonPatchDocument<PaymentDTO> patchDoc);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}