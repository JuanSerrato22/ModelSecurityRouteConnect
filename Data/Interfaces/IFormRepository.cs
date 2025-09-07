using Entity.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IFormRepository
    {
        Task<List<Form>> GetAllAsync();
        Task<Form> GetByIdAsync(int id);
        Task<Form> CreateAsync(Form form);
        Task<Form> UpdateAsync(Form form);
        Task<bool> DeleteAsync(int id);
    }
}