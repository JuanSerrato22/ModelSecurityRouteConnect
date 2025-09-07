using Entity.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUserActivityRepository
    {
        Task<List<UserActivity>> GetAllAsync();
        Task<UserActivity> GetByIdAsync(int id);
        Task<UserActivity> CreateAsync(UserActivity userActivity);
        Task<UserActivity> UpdateAsync(UserActivity userActivity);
        Task<bool> DeleteAsync(int id);
    }
}