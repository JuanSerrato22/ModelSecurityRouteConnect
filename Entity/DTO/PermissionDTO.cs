
using Entity.Model.Base;

namespace Entity.DTO
{
    public class PermissionDTO : BaseEntity
    {
        public required string PermissionName { get; set; }
        public string? Description { get; set; }
    }
}