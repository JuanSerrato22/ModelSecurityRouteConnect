using AutoMapper;
using Business.Interfaces;
using Data.Implements;
using Data.Interfaces;
using Entity.DTO;
using Entity.Model;
using Microsoft.AspNetCore.JsonPatch;
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

        public async Task<PaymentDTO> UpdatePartialAsync(int id, JsonPatchDocument<PaymentDTO> patchDoc)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);
            if (payment == null) return null!;

            var paymentDto = _mapper.Map<PaymentDTO>(payment);
            patchDoc.ApplyTo(paymentDto);

            // Mapea de nuevo a la entidad y actualiza
            _mapper.Map(paymentDto, payment);
            var updated = await _paymentRepository.UpdateAsync(payment);
            return _mapper.Map<PaymentDTO>(updated);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);
            if (payment == null) return false;

            if (payment.Active)
            {
                payment.Active = false;
                payment.DeleteAt = DateTime.Now;
            }
            else
            {
                payment.Active = true;
                payment.DeleteAt = null;
            }

            await _paymentRepository.UpdateAsync(payment);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _paymentRepository.DeleteAsync(id);
        }
    }
}