
using Entity.Model.Base;

namespace Entity.DTO
{
    public class PermissionDTO
    {
        public int Id { get; set; }
        public string? PermissionName { get; set; }
        public string? Description { get; set; }
    }
}