using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IUserController
    {
        Task<ActionResult<IEnumerable<UserDto>>> GetAll();
        public Task<ActionResult<User>> Save([FromBody] UserDto userDto);
        public Task<IActionResult> Update([FromBody] UserDto user);
        public Task<IActionResult> Delete(int id);
    }
}
