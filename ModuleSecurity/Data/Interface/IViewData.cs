using Entity.DTO;
using Entity.Model.Security;


namespace Data.Interface
{
    public interface IViewData
    {
        Task Delete(int id);
        Task<IEnumerable<View>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<View> GetById(int id);
        Task<View> Save(View view);
        Task Update(View view);
        Task<View> GetByName(string name);
    }
}
