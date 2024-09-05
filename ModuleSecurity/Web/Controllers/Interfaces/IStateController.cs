using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IStateController
    {
        Task<ActionResult<IEnumerable<StateDto>>> GetAll();
        public Task<ActionResult<State>> Save([FromBody] StateDto stateDto);
        public Task<IActionResult> Update([FromBody] StateDto stateDto);
        public Task<IActionResult> Delete(int id);
    }
}
