using Entity.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IFormModuleRepository
    {
        Task<List<FormModule>> GetAllAsync();
        Task<FormModule> GetByIdAsync(int id);
        Task<FormModule> CreateAsync(FormModule formModule);
        Task<FormModule> UpdateAsync(FormModule formModule);
        Task<bool> DeleteAsync(int id);
    }
}