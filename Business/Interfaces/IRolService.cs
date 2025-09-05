using Entity.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRolService
    {
        Task<List<RolDTO>> GetAllAsync();
        Task<RolDTO> GetByIdAsync(int id);
        Task<RolDTO> CreateAsync(RolDTO rolDto);
        Task<RolDTO> UpdateAsync(int id, RolDTO rolDto);
        Task<bool> DeleteAsync(int id);
    }
}