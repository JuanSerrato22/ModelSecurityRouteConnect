using Entity.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRolFormPermissionService
    {
        Task<List<RolFormPermissionDTO>> GetAllAsync();
        Task<RolFormPermissionDTO> GetByIdAsync(int id);
        Task<RolFormPermissionDTO> CreateAsync(RolFormPermissionDTO rolFormPermissionDto);
        Task<RolFormPermissionDTO> UpdateAsync(int id, RolFormPermissionDTO rolFormPermissionDto);
        Task<bool> DeleteAsync(int id);
    }
}