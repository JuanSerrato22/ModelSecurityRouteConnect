using Entity.DTO;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserActivityService
    {
        Task<List<UserActivityDTO>> GetAllAsync();
        Task<UserActivityDTO> GetByIdAsync(int id);
        Task<UserActivityDTO> CreateAsync(UserActivityDTO userActivityDto);
        Task<UserActivityDTO> UpdateAsync(int id, UserActivityDTO userActivityDto);
        Task<UserActivityDTO> UpdatePartialAsync(int id, JsonPatchDocument<UserActivityDTO> patchDoc);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}