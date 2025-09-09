using Entity.DTO;
using Microsoft.AspNetCore.JsonPatch;
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
        Task<PermissionDTO> UpdatePartialAsync(int id, JsonPatchDocument<PermissionDTO> patchDoc);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}