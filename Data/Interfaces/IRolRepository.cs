using Entity.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRolRepository
    {
        Task<List<Rol>> GetAllAsync();
        Task<Rol> GetByIdAsync(int id);
        Task<Rol> CreateAsync(Rol rol);
        Task<Rol> UpdateAsync(Rol rol);
        Task<bool> DeleteAsync(int id);
    }
}