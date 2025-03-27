using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    internal class Pay
    {
        public int PayId { get; set; }
        public int Amount { get; set; }
        public int PayDate { get; set; }
        public string PayMethod { get; set; }
        public int PaymentReference { get; set; }
    }
}
