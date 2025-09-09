using Entity.DTO;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserRolService
    {
        Task<List<UserRolDTO>> GetAllAsync();
        Task<UserRolDTO> GetByIdAsync(int id);
        Task<UserRolDTO> CreateAsync(UserRolDTO userUserRolDto);
        Task<UserRolDTO> UpdateAsync(int id, UserRolDTO userUserRolDto);
        Task<UserRolDTO> UpdatePartialAsync(int id, JsonPatchDocument<UserRolDTO> patchDoc);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}