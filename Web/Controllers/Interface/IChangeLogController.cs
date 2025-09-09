using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Entity.DTO;
using System.Threading.Tasks;

namespace Web.Controllers.Interface
{
    public interface IChangeLogController
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetById(int id);
        Task<IActionResult> Create(ChangeLogDTO changeLogDto);
        Task<IActionResult> Update(int id, ChangeLogDTO changeLogDto);
        Task<IActionResult> UpdatePartial(int id, ChangeLogDTO changeLogDto);
        Task<IActionResult> SoftDelete(int id);
        Task<IActionResult> Delete(int id);
    }
}