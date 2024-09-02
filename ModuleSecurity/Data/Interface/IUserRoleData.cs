using Entity.DTO;
using Entity.Model.Security;


namespace Data.Interface
{
    public interface IUserRoleData
    {
        Task Delete(int id);
        Task<IEnumerable<UserRole>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<UserRole> GetById(int id);
        Task<UserRole> Save(UserRole userRole);
        Task Update(UserRole userRole);
        Task<UserRole> GetByName(int id);
    }
}
