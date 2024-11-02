
using Business.Implements;
using Business.Interface;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interfaces;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase, ICityController
    {
        private readonly ICityBusiness _cityBusiness;

        public CityController(ICityBusiness cityBusiness)
        {
            _cityBusiness = cityBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetAll()
        {
            var result = await _cityBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CityDto>> GetById(int id)
        {
            var result = await _cityBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<City>> Save([FromBody] CityDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _cityBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CityDto entity)
        {
            if (entity == null || entity.Id == 0)
            {
                return BadRequest();
            }
            await _cityBusiness.Update(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromQuery] bool isSoftDelete)
        {
            await _cityBusiness.Delete(id, isSoftDelete);
            return NoContent();
        }

        Task ICityController.Delete(int id, bool isSoftDelete)
        {
            throw new NotImplementedException();
        }
    }
}
