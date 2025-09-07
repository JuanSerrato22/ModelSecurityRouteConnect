using System;
using Entity.Model.Base;


namespace Entity.Model
{
    public class Payment : BaseEntity
    {
        public required string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public required string Activity { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}