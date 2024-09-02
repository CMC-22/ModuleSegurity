using Entity.DTO;
using Entity.Model.Security;

namespace Bussines.Implements
{
    public interface IUserRoleBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<UserRoleDto>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<UserRoleDto> GetById(int id);
        UserRole MapearDatos(UserRole userRole, UserRoleDto entity);
        Task<UserRole> Save(UserRoleDto entity);
        Task Update(UserRoleDto entity);
    }
}