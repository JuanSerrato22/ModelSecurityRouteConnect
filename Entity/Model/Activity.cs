using System;
using Entity.Model.Base;

namespace Entity.Model
{
    public class Activity : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
        public TimeSpan DurationHours { get; set; } = TimeSpan.Zero; // Fixed initialization
    }

}