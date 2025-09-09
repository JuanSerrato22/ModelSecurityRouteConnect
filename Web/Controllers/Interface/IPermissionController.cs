using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Entity.DTO;
using System.Threading.Tasks;

namespace Web.Controllers.Interface
{
    public interface IPermissionController
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetById(int id);
        Task<IActionResult> Create(PermissionDTO permissionDto);
        Task<IActionResult> Update(int id, PermissionDTO permissionDto);
        Task<IActionResult> UpdatePartial(int id, PermissionDTO permissionDto);
        Task<IActionResult> SoftDelete(int id);
        Task<IActionResult> Delete(int id);
    }
}