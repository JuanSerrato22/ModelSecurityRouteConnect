using Entity.DTO;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRolFormPermissionService
    {
        Task<List<RolFormPermissionDTO>> GetAllAsync();
        Task<RolFormPermissionDTO> GetByIdAsync(int id);
        Task<RolFormPermissionDTO> CreateAsync(RolFormPermissionDTO rolFormPermissionDto);
        Task<RolFormPermissionDTO> UpdateAsync(int id, RolFormPermissionDTO rolFormPermissionDto);
        Task<RolFormPermissionDTO> UpdatePartialAsync(int id, JsonPatchDocument<RolFormPermissionDTO> patchDoc);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}