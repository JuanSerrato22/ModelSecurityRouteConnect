using Entity.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserRolService
    {
        Task<List<UserRolDTO>> GetAllAsync();
        Task<UserRolDTO> GetByIdAsync(int id);
        Task<UserRolDTO> CreateAsync(UserRolDTO userUserRolDto);
        Task<UserRolDTO> UpdateAsync(int id, UserRolDTO userUserRolDto);
        Task<bool> DeleteAsync(int id);
    }
}