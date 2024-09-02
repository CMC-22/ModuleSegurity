using Entity.DTO;
using Entity.Model.Security;

namespace Bussines.Implements
{
    public interface IViewBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<ViewDto>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<ViewDto> GetById(int id);
        View MapearDatos(View view, ViewDto entity);
        Task<View> Save(ViewDto entity);
        Task Update(ViewDto entity);
    }
}