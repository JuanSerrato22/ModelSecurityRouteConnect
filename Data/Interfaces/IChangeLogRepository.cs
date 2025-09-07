using Entity.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IChangeLogRepository
    {
        Task<List<ChangeLog>> GetAllAsync();
        Task<ChangeLog> GetByIdAsync(int id);
        Task<ChangeLog> CreateAsync(ChangeLog changelog);
        Task<ChangeLog> UpdateAsync(ChangeLog changelog);
        Task<bool> DeleteAsync(int id);
    }
}