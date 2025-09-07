using Entity.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IModuleRepository
    {
        Task<List<Module>> GetAllAsync();
        Task<Module> GetByIdAsync(int id);
        Task<Module> CreateAsync(Module module);
        Task<Module> UpdateAsync(Module module);
        Task<bool> DeleteAsync(int id);
    }
}