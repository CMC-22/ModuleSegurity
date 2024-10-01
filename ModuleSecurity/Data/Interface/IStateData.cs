using Entity.DTO;
using Entity.Model.Security;


namespace Data.Interface
{
    public interface IStateData
    {
        Task Delete(int id, bool isSoftDelete = true);
        Task<IEnumerable<StateDto>>GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<State> GetById(int id);
        Task<State> Save(State entity);
        Task Update(State entity);
        Task<State> GetByName(string name);
    }
}
