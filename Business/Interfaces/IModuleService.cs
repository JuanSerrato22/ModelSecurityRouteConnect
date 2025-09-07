using Entity.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IModuleService
    {
        Task<List<ModuleDTO>> GetAllAsync();
        Task<ModuleDTO> GetByIdAsync(int id);
        Task<ModuleDTO> CreateAsync(ModuleDTO moduleDto);
        Task<ModuleDTO> UpdateAsync(int id, ModuleDTO moduleDto);
        Task<bool> DeleteAsync(int id);
    }
}