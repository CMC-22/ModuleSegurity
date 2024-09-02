using Entity.DTO;
using Entity.Model.Security;


namespace Bussines.Interface
{
    public interface IRoleBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<RoleDto>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<RoleDto> GetById(int id);
        Task<Role> Save(RoleDto entity);
        Task Update(RoleDto entity);

    }
}
