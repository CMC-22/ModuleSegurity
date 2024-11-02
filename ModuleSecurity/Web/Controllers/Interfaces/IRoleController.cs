using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IRoleController
    {
        Task<ActionResult<IEnumerable<RoleDto>>> GetAll();
        public Task<ActionResult<Role>> Save([FromBody] RoleDto roleDto);
        public Task<IActionResult> Update([FromBody] RoleDto roleDto);
        public Task<IActionResult> Delete(int id, bool isSoftDelete);
    }
}
