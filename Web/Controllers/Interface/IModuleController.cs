using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Entity.DTO;
using System.Threading.Tasks;

namespace Web.Controllers.Interface
{
    public interface IModuleController
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetById(int id);
        Task<IActionResult> Create(ModuleDTO moduleDto);
        Task<IActionResult> Update(int id, ModuleDTO moduleDto);
        Task<IActionResult> UpdatePartial(int id, ModuleDTO moduleDto);
        Task<IActionResult> SoftDelete(int id);
        Task<IActionResult> Delete(int id);
    }
}