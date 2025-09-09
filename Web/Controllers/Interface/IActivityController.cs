using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Entity.DTO;
using System.Threading.Tasks;

namespace Web.Controllers.Interface
{
    public interface IActivityController
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetById(int id);
        Task<IActionResult> Create(ActivityDTO activityDto);
        Task<IActionResult> Update(int id, ActivityDTO activityDto);
        Task<IActionResult> UpdatePartial(int id, ActivityDTO activityDTO);
        Task<IActionResult> SoftDelete(int id);
        Task<IActionResult> Delete(int id);
    }
}