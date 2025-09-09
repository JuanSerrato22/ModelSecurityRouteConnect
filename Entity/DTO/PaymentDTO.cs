using System;
using Entity.Model.Base;


namespace Entity.DTO
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public string? PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public string? Activity { get; set; }
    }
}

