using Entity.DTO;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRolPermissionService
    {
        Task<List<RolPermissionDTO>> GetAllAsync();
        Task<RolPermissionDTO> GetByIdAsync(int id);
        Task<RolPermissionDTO> CreateAsync(RolPermissionDTO rolPermissionDto);
        Task<RolPermissionDTO> UpdateAsync(int id, RolPermissionDTO rolPermissionDto);
        Task<RolPermissionDTO> UpdatePartialAsync(int id, JsonPatchDocument<RolPermissionDTO> patchDoc);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}