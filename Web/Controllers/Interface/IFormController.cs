using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Entity.DTO;
using System.Threading.Tasks;

namespace Web.Controllers.Interface
{
    public interface IFormController
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetById(int id);
        Task<IActionResult> Create(FormDTO formDto);
        Task<IActionResult> Update(int id, FormDTO formDto);
        Task<IActionResult> Delete(int id);
    }
}