using Entity.DTO;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRolService
    {
        Task<List<RolDTO>> GetAllAsync();
        Task<RolDTO> GetByIdAsync(int id);
        Task<RolDTO> CreateAsync(RolDTO rolDto);
        Task<RolDTO> UpdateAsync(int id, RolDTO rolDto);
        Task<RolDTO> UpdatePartialAsync(int id, JsonPatchDocument<RolDTO> patchDoc);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}