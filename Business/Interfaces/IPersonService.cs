using Entity.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IPersonService
    {
        Task<List<PersonDTO>> GetAllAsync();
        Task<PersonDTO> GetByIdAsync(int id);
        Task<PersonDTO> CreateAsync(PersonDTO personDto);
        Task<PersonDTO> UpdateAsync(int id, PersonDTO personDto);
        Task<bool> DeleteAsync(int id);
    }
}