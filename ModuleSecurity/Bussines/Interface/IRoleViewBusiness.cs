using Entity.DTO;
using Entity.Model.Security;


namespace Bussines.Interface
{
    public interface IRoleViewBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<RoleViewDto>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<RoleViewDto> GetById(int id);
        Task<RoleView> Save(RoleViewDto entity);
        Task Update(RoleViewDto entity);

    }
}
