using System;

namespace Entity.Model.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeleteAt { get; set; }
    }
}