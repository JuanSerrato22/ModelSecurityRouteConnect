using Entity.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IPermissionService
    {
        Task<List<PermissionDTO>> GetAllAsync();
        Task<PermissionDTO> GetByIdAsync(int id);
        Task<PermissionDTO> CreateAsync(PermissionDTO permissionDto);
        Task<PermissionDTO> UpdateAsync(int id, PermissionDTO permissionDto);
        Task<bool> DeleteAsync(int id);
    }
}