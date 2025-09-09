using Entity.DTO;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IFormModuleService
    {
        Task<List<FormModuleDTO>> GetAllAsync();
        Task<FormModuleDTO> GetByIdAsync(int id);
        Task<FormModuleDTO> CreateAsync(FormModuleDTO formModuleDto);
        Task<FormModuleDTO> UpdateAsync(int id, FormModuleDTO formModuleDto);
        Task<FormModuleDTO> UpdatePartialAsync(int id, JsonPatchDocument<FormModuleDTO> patchDoc);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}