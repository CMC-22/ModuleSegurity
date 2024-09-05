using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface ICityController
    {
        Task<ActionResult<IEnumerable<CityDto>>> GetAll();
        public Task<ActionResult<City>> Save([FromBody] CityDto cityDto);
        public Task<IActionResult> Update([FromBody] CityDto cityDto);
        public Task<IActionResult> Delete(int id);
    }
}
