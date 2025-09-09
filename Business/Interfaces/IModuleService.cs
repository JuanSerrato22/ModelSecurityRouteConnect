using Entity.DTO;
using Microsoft.AspNetCore.JsonPatch;
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
        Task<ModuleDTO> UpdatePartialAsync(int id, JsonPatchDocument<ModuleDTO> patchDoc);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}