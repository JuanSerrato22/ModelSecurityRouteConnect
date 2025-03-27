using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    class Destination
    {
        public int DestinationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Latitude { get; set; }
        public int Length { get; set; }
        public string Address { get; set; }
        public int OpeningHours { get; set; }
        public string Recomendations { get; set; }
        public string Weather { get; set; }
    }
}
