using Entity.DTO;
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
        Task<bool> DeleteAsync(int id);
    }
}