using Entity.DTO;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IFormService
    {
        Task<List<FormDTO>> GetAllAsync();
        Task<FormDTO> GetByIdAsync(int id);
        Task<FormDTO> CreateAsync(FormDTO formDto);
        Task<FormDTO> UpdateAsync(int id, FormDTO formDto);
        Task<FormDTO> UpdatePartialAsync(int id, JsonPatchDocument<FormDTO> patchDoc);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}