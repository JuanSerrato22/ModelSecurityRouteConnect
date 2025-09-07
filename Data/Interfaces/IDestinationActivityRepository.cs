using Entity.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IDestinationActivityRepository
    {
        Task<List<DestinationActivity>> GetAllAsync();
        Task<DestinationActivity> GetByIdAsync(int id);
        Task<DestinationActivity> CreateAsync(DestinationActivity destinationActivity);
        Task<DestinationActivity> UpdateAsync(DestinationActivity destinationActivity);
        Task<bool> DeleteAsync(int id);
    }
}