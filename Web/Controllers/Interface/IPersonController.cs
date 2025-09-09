using Entity.DTO;
using Entity.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers.Interface
{
    public interface IPersonController
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetById(int id);
        Task<IActionResult> Create(PersonDTO personDto);
        Task<IActionResult> Update(int id, PersonDTO personDto);
        Task<IActionResult> UpdatePartial(int id, PersonDTO personDTO);
        Task<IActionResult> SoftDelete(int id);
        Task<IActionResult> Delete(int id);
    }
}