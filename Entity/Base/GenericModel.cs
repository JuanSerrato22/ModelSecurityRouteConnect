using System;

namespace Entity.Model.Base
{
    public class GenericModel : BaseEntity
    {
        public bool Active { get; set; }

        // Constructor para inicializar Active y heredar CreatedAt
        public GenericModel()
        {
            Active = true;
        }

        // Sobrescribir soft delete para incluir Active
        public new void SoftDelete()
        {
            Active = false;
            base.SoftDelete();
        }

        // Restaurar
        public new void Restore()
        {
            Active = true;
            base.Restore();
        }
    }
}
