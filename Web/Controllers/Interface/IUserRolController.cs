using Entity.DTO;
using Entity.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers.Interface
{
    public interface IUserRolController
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetById(int id);
        Task<IActionResult> Create(UserRolDTO userRolDto);
        Task<IActionResult> Update(int id, UserRolDTO userRolDto);
        Task<IActionResult> UpdatePartial(int id, UserRolDTO userRolDTO);
        Task<IActionResult> SoftDelete(int id);
        Task<IActionResult> Delete(int id);
    }
}