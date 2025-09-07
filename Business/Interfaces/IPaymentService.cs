using Entity.DTO;
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
        Task<bool> DeleteAsync(int id);
    }
}