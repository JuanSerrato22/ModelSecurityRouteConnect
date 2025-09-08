using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Entity.DTO;
using System.Threading.Tasks;

namespace Web.Controllers.Interface
{
    public interface IDestinationActivityController
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetById(int id);
        Task<IActionResult> Create(DestinationActivityDTO destinationActivityDto);
        Task<IActionResult> Delete(int id);
    }
}