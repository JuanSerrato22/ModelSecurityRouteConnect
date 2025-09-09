using Entity.DTO;
using Entity.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers.Interface
{
    public interface IUserActivityController
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetById(int id);
        Task<IActionResult> Create(UserActivityDTO userActivityDto);
        Task<IActionResult> Update(int id, UserActivityDTO userActivityDto);
        Task<IActionResult> UpdatePartial(int id, UserActivityDTO userActivityDTO);
        Task<IActionResult> SoftDelete(int id);
        Task<IActionResult> Delete(int id);
    }
}