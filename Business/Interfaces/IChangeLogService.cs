using Entity.DTO;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IChangeLogService
    {
        Task<List<ChangeLogDTO>> GetAllAsync();
        Task<ChangeLogDTO> GetByIdAsync(int id);
        Task<ChangeLogDTO> CreateAsync(ChangeLogDTO changelogDto);
        Task<ChangeLogDTO> UpdateAsync(int id, ChangeLogDTO changelogDto);
        Task<ChangeLogDTO> UpdatePartialAsync(int id, JsonPatchDocument<ChangeLogDTO> patchDoc);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}