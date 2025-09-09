using Entity.DTO;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IDestinationActivityService
    {
        Task<List<DestinationActivityDTO>> GetAllAsync();
        Task<DestinationActivityDTO> GetByIdAsync(int id);
        Task<DestinationActivityDTO> CreateAsync(DestinationActivityDTO destinationActivityDto);
        Task<DestinationActivityDTO> UpdateAsync(int id, DestinationActivityDTO destinationActivityDto);
        Task<DestinationActivityDTO> UpdatePartialAsync(int id, JsonPatchDocument<DestinationActivityDTO> patchDoc);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}