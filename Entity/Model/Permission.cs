
using Entity.Model.Base;


namespace Entity.Model
{
    public class Permission : GenericModel
    {
        public string? PermissionName { get; set; }
        public string? Description { get; set; }
    }
}