using Entity.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUserRolRepository
    {
        Task<List<UserRol>> GetAllAsync();
        Task<UserRol> GetByIdAsync(int id);
        Task<UserRol> CreateAsync(UserRol userUserRol);
        Task<UserRol> UpdateAsync(UserRol userUserRol);
        Task<bool> DeleteAsync(int id);
    }
}