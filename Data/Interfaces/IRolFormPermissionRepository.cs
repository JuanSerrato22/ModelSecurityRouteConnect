using Entity.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRolFormPermissionRepository
    {
        Task<List<RolFormPermission>> GetAllAsync();
        Task<RolFormPermission> GetByIdAsync(int id);
        Task<RolFormPermission> CreateAsync(RolFormPermission rolFormPermission);
        Task<RolFormPermission> UpdateAsync(RolFormPermission rolFormPermission);
        Task<bool> DeleteAsync(int id);
    }
}