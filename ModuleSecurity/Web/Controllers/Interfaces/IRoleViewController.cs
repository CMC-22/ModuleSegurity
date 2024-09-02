using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IRoleViewController
    {
        Task<ActionResult<IEnumerable<RoleViewDto>>> GetAll();
        public Task<ActionResult<RoleView>> Save([FromBody] RoleViewDto roleViewDto);
        public Task<IActionResult> Update([FromBody] RoleViewDto roleViewDto);
        public Task<IActionResult> Delete(int id);
    }
}
