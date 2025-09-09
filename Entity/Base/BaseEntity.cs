using System;

namespace Entity.Model.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeleteAt { get; set; }

        // Constructor para inicializar CreatedAt
        protected BaseEntity()
        {
            CreatedAt = DateTime.Now;
            DeleteAt = null;
        }

        // Método de soft delete
        public void SoftDelete()
        {
            DeleteAt = DateTime.Now;
        }

        // Reactivar
        public void Restore()
        {
            DeleteAt = null;
        }

        // Verificar si está activo
        public bool IsActive() => DeleteAt == null;
    }
}
