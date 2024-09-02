using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interface
{
    public interface IPersonData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Person> GetById(int id);
        Task<Person> Save(Person entity);
        Task Update(Person entity);
        Task<Person> GetByName(string first_name);
        Task<IEnumerable<Person>> GetAll();
    }
}
