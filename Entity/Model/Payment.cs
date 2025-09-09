using System;
using Entity.Model.Base;


namespace Entity.Model
{
    public class Payment : GenericModel
    {
        public string? PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public string? Activity { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}