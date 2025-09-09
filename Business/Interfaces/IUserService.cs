using Entity.DTO;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllAsync();
        Task<UserDTO> GetByIdAsync(int id);
        Task<UserDTO> CreateAsync(UserDTO userDto);
        Task<UserDTO> UpdateAsync(int id, UserDTO userDto);
        Task<UserDTO> UpdatePartialAsync(int id, JsonPatchDocument<UserDTO> patchDoc);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}