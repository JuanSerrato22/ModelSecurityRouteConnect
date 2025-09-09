using Entity.DTO;
using Entity.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers.Interface
{
    public interface IFormModuleController
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetById(int id);
        Task<IActionResult> Create(FormModuleDTO formModuleDto);
        Task<IActionResult> Update(int id, FormModuleDTO formModuleDto);
        Task<IActionResult> UpdatePartial(int id, FormModuleDTO formModuleDTO);
        Task<IActionResult> SoftDelete(int id);
        Task<IActionResult> Delete(int id);
    }
}