using Entity.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRolPermissionService
    {
        Task<List<RolPermissionDTO>> GetAllAsync();
        Task<RolPermissionDTO> GetByIdAsync(int id);
        Task<RolPermissionDTO> CreateAsync(RolPermissionDTO rolPermissionDto);
        Task<RolPermissionDTO> UpdateAsync(int id, RolPermissionDTO rolPermissionDto);
        Task<bool> DeleteAsync(int id);
    }
}