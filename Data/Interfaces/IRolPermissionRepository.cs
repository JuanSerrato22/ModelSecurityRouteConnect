using Entity.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRolPermissionRepository
    {
        Task<List<RolPermission>> GetAllAsync();
        Task<RolPermission> GetByIdAsync(int id);
        Task<RolPermission> CreateAsync(RolPermission rolPermission);
        Task<RolPermission> UpdateAsync(RolPermission rolPermission);
        Task<bool> DeleteAsync(int id);
    }
}