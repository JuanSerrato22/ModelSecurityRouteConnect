namespace Entity.Model
{
    public class Destination
    {
        public int DestinationId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Region { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}