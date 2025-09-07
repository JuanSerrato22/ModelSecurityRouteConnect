using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Base;


namespace Entity.DTO
{
    public class DestinationActivityDTO : BaseEntity
    {
        public int DestinationId { get; set; }
        public int ActivityId { get; set; }
    }
}