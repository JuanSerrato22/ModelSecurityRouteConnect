using Entity.DTO;
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
        Task<bool> DeleteAsync(int id);
    }
}