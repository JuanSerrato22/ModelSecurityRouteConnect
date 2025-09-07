using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Model;
using Entity.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<List<PaymentDTO>> GetAllAsync()
        {
            var payment = await _paymentRepository.GetAllAsync();
            return _mapper.Map<List<PaymentDTO>>(payment);
        }

        public async Task<PaymentDTO> GetByIdAsync(int id)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);
            return _mapper.Map<PaymentDTO>(payment);
        }

        public async Task<PaymentDTO> CreateAsync(PaymentDTO paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);
            var paymentCreado = await _paymentRepository.CreateAsync(payment);
            return _mapper.Map<PaymentDTO>(paymentCreado);
        }

        public async Task<PaymentDTO> UpdateAsync(int id, PaymentDTO paymentDto)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);
            if (payment == null) return null!; // Devuelve null forzando la nulabilidad, pero cumple la firma

            payment.PaymentMethod = paymentDto.PaymentMethod;
            payment.Amount = paymentDto.Amount;
            payment.Activity = paymentDto.Activity;

            var actualizado = await _paymentRepository.UpdateAsync(payment);
            return _mapper.Map<PaymentDTO>(actualizado);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _paymentRepository.DeleteAsync(id);
        }
    }
}