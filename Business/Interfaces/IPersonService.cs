using Entity.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;


namespace Business.Interfaces
{
    public interface IPersonService
    {
        Task<List<PersonDTO>> GetAllAsync();
        Task<PersonDTO> GetByIdAsync(int id);
        Task<PersonDTO> CreateAsync(PersonDTO personDto);
        Task<PersonDTO> UpdateAsync(int id, PersonDTO personDto);
        Task<PersonDTO> UpdatePartialAsync(int id, JsonPatchDocument<PersonDTO> patchDoc);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}