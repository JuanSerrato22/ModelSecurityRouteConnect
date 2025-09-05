using Entity.DTO;
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
        Task<bool> DeleteAsync(int id);
    }
}