using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IUserRoleController
    {
        Task<ActionResult<IEnumerable<UserRoleDto>>> GetAll();
        public Task<ActionResult<UserRole>> Save([FromBody] UserRoleDto userRoleDto);
        public Task<IActionResult> Update([FromBody] UserRoleDto userRoleDto);
        public Task<IActionResult> Delete(int id);
    }
}
