using Entity.DTO;
using Entity.Model.Security;


namespace Data.Interface
{
    public interface ICityData
    {
        Task Delete(int id, bool isSoftDelete = true);
        Task<IEnumerable<CityDto>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<City> GetById(int id);
        Task<City> Save(City entity);
        Task Update(City entity);
        Task<City> GetByName(string name);

    }
}
