using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Entity.DTO;
using System.Threading.Tasks;

namespace Web.Controllers.Interface
{
    public interface IPersonController
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetById(int id);
        Task<IActionResult> Create(PersonDTO personDto);
        Task<IActionResult> Update(int id, PersonDTO personDto);
        Task<IActionResult> Delete(int id);
    }
}