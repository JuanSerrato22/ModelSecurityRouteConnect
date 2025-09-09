using Entity.DTO;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IDestinationService
    {
        Task<List<DestinationDTO>> GetAllAsync();
        Task<DestinationDTO> GetByIdAsync(int id);
        Task<DestinationDTO> CreateAsync(DestinationDTO destinationDto);
        Task<DestinationDTO> UpdateAsync(int id, DestinationDTO destinationDto);
        Task<DestinationDTO> UpdatePartialAsync(int id, JsonPatchDocument<DestinationDTO> patchDoc);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}