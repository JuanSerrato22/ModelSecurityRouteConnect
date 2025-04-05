using System;

namespace Entity.DTO
{
    public class PaymentDTO
    {
        public int PaymentId { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public string Activity { get; set; }
    }
}

