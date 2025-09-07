
using Entity.Model.Base;


namespace Entity.Model
{
    public class Permission : BaseEntity
    {
        public required string PermissionName { get; set; }
        public string? Description { get; set; }
    }
}