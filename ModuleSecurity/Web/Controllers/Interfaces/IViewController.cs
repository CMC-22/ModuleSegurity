using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    
    public interface IViewController
    {
        Task<ActionResult<IEnumerable<ViewDto>>> GetAll();
        public Task<ActionResult<View>> Save([FromBody] ViewDto viewDto);
        public Task<IActionResult> Update([FromBody] ViewDto viewDto);
        public Task<IActionResult> Delete(int id);
    }
}
