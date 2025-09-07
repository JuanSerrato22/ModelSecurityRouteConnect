using Entity.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IPermissionRepository
    {
        Task<List<Permission>> GetAllAsync();
        Task<Permission> GetByIdAsync(int id);
        Task<Permission> CreateAsync(Permission permission);
        Task<Permission> UpdateAsync(Permission permission);
        Task<bool> DeleteAsync(int id);
    }
}