
using Entity.Model.Base;

namespace Entity.DTO
{
    public class RolDTO : BaseEntity
    {
        public string? RolName { get; set; }
        public string? Description { get; set; }
    }
}