using Entity.DTO;
using Entity.Model.Security;


namespace Data.Interface
{
    public interface IViewData
    {
        Task Delete(int id, bool isSoftDelete = true);
        Task<IEnumerable<ViewDto>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<View> GetById(int id);
        Task<View> Save(View view);
        Task Update(View view);
        Task<View> GetByName(string name);
    }
}
