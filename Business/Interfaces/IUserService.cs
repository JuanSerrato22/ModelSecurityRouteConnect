using Entity.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllAsync();
        Task<UserDTO> GetByIdAsync(int id);
        Task<UserDTO> CreateAsync(UserDTO userDto);
        Task<UserDTO> UpdateAsync(int id, UserDTO userDto);
        Task<bool> DeleteAsync(int id);
    }
}