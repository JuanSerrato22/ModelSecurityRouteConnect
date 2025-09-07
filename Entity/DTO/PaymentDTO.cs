using System;
using Entity.Model.Base;


namespace Entity.DTO
{
    public class PaymentDTO : BaseEntity
    {
        public required string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public required string Activity { get; set; }
    }
}

