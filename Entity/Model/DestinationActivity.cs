using Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entity.Model
{
    public class DestinationActivity : GenericModel
    {
        public int DestinationId { get; set; }
        public int ActivityId { get; set; }
    }
}
