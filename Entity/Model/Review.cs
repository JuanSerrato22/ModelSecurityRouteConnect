using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    internal class Review
    {
        public int ReviewId { get; set; }
        public int Qualification { get; set; }
        public string Comment { get; set; }
        public string ReviewDate { get; set; }
    }
}
