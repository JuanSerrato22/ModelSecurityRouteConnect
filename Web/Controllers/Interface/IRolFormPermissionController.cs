using Entity.DTO;
using Entity.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers.Interface
{
    public interface IRolFormPermissionController
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetById(int id);
        Task<IActionResult> Create(RolFormPermissionDTO rolFormPermissionDto);
        Task<IActionResult> Update(int id, RolFormPermissionDTO rolFormPermissionDto);
        Task<IActionResult> UpdatePartial(int id, RolFormPermissionDTO rolFormPermissionDTO);
        Task<IActionResult> SoftDelete(int id);
        Task<IActionResult> Delete(int id);
    }
}