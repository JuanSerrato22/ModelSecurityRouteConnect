using Entity.DTO;
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
        Task<bool> DeleteAsync(int id);
    }
}