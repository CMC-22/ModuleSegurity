using Entity.DTO;
using Entity.Model.Security;

namespace Bussines.Implements
{
    public interface IUserBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<UserDto> GetById(int id);
        User MapearDatos(User user, UserDto entity);
        Task<User> Save(UserDto entity);
        Task Update(UserDto entity);
    }
}