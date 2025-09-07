using Entity.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IDestinationActivityService
    {
        Task<List<DestinationActivityDTO>> GetAllAsync();
        Task<DestinationActivityDTO> GetByIdAsync(int id);
        Task<DestinationActivityDTO> CreateAsync(DestinationActivityDTO destinationActivityDto);
        Task<bool> DeleteAsync(int id);
    }
}