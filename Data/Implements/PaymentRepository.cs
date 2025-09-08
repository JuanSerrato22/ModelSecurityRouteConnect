using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Implements
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            return await _context.Payment.ToListAsync();
        }

        public async Task<Payment> GetByIdAsync(int id)
        {
            var payment = await _context.Payment.FirstOrDefaultAsync(c => c.Id == id);
            if (payment == null)
                throw new InvalidOperationException($"No se encontró un Pago con el id {id}.");
            return payment;
        }

        public async Task<Payment> CreateAsync(Payment payment)
        {
            _context.Payment.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> UpdateAsync(Payment payment)
        {
            _context.Payment.Update(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var payment = await _context.Payment.FindAsync(id);
            if (payment == null) return false;
            _context.Payment.Remove(payment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}