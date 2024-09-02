using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IModuloController
    {
        Task<ActionResult<IEnumerable<ModuloDto>>> GetAll();
        public Task<ActionResult<Modulo>> Save([FromBody] ModuloDto moduloDto);
        public Task<IActionResult> Update([FromBody] ModuloDto moduloDto);
        public Task<IActionResult> Delete(int id);
    }
}
