using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Entity.DTO;
using System.Threading.Tasks;

namespace Web.Controllers.Interface
{
    public interface IDestinationController
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetById(int id);
        Task<IActionResult> Create(DestinationDTO destinationDto);
        Task<IActionResult> Update(int id, DestinationDTO destinationDto);
        Task<IActionResult> UpdatePartial(int id, DestinationDTO destinationDto);
        Task<IActionResult> SoftDelete(int id);
        Task<IActionResult> Delete(int id);
    }
}