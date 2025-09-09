using Entity.DTO;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Business.Interfaces
{
    public interface IActivityService
    {
        Task<List<ActivityDTO>> GetAllAsync();
        Task<ActivityDTO> GetByIdAsync(int id);
        Task<ActivityDTO> CreateAsync(ActivityDTO activityDto);
        Task<ActivityDTO> UpdateAsync(int id, ActivityDTO activityDto);
        Task<ActivityDTO> UpdatePartialAsync(int id, JsonPatchDocument<ActivityDTO> patchDoc);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}