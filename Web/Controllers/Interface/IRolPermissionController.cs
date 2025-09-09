using Entity.DTO;
using Entity.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers.Interface
{
    public interface IRolPermissionController
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetById(int id);
        Task<IActionResult> Create(RolPermissionDTO rolPermissionDto);
        Task<IActionResult> Update(int id, RolPermissionDTO rolPermissionDto);
        Task<IActionResult> UpdatePartial(int id, RolPermissionDTO rolPermissionDTO);
        Task<IActionResult> SoftDelete(int id);
        Task<IActionResult> Delete(int id);
    }
}