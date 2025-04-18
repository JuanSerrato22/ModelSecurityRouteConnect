using System;

namespace Entity.Model
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Category { get; set; }
        public decimal Price { get; set; }
        public DateTime DurationHours { get; set; }
        public bool Available { get; set; }
    }

}