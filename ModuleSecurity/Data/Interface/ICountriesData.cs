using Entity.DTO;
using Entity.Model.Security;


namespace Data.Interface
{
    public interface ICountriesData
    {
        Task Delete(int id, bool isSoftDelete = true);
        Task<IEnumerable<CountriesDto>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Countries> GetById(int id);
        Task<Countries> Save(Countries entity);
        Task Update(Countries entity);
        Task<Countries> GetByName(string name);
    }
}
