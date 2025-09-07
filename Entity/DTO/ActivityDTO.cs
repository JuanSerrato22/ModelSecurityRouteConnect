using System;
using Entity.Model.Base;


namespace Entity.DTO
{
    public class ActivityDTO : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
        public TimeSpan DurationHours { get; set; }

    }

}