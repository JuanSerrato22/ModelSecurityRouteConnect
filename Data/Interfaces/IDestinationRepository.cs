using Entity.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IDestinationRepository
    {
        Task<List<Destination>> GetAllAsync();
        Task<Destination> GetByIdAsync(int id);
        Task<Destination> CreateAsync(Destination destination);
        Task<Destination> UpdateAsync(Destination destination);
        Task<bool> DeleteAsync(int id);
    }
}