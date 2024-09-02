using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IPersonController
    {
        Task<ActionResult<IEnumerable<PersonDto>>> GetAll();
        public Task<ActionResult<Person>> Save([FromBody] PersonDto personDto);
        public Task<IActionResult> Update([FromBody] PersonDto personDto);
        public Task<IActionResult> Delete(int id);
    }
}
