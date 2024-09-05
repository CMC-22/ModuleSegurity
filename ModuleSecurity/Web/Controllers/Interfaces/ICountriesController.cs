using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface ICountriesController
    {
        Task<ActionResult<IEnumerable<CountriesDto>>> GetAll();
        public Task<ActionResult<Countries>> Save([FromBody] CountriesDto countriesDto);
        public Task<IActionResult> Update([FromBody] CountriesDto countriesDto);
        public Task<IActionResult> Delete(int id);
    }
}
