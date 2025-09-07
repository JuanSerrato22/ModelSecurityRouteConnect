
using Entity.Model.Base;


namespace Entity.DTO
{
    public class DestinationDTO : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
