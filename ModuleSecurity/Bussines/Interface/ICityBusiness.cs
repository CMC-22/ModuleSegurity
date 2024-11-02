using Entity.DTO;
using Entity.Model.Security;


namespace Business.Interface
{
    public interface ICityBusiness
    {
        Task Delete(int id, bool isSoftDelete);
        Task<IEnumerable<CityDto>> GetAll();
        Task<CityDto> GetById(int id);
        Task<City> Save(CityDto entity);
        Task Update(CityDto entity);
    }
}
