using Entity.DTO;
using Entity.Model.Security;
<<<<<<< HEAD
=======

>>>>>>> 90d74f609e8c07d10b0c9772d81c5c5d745185e0

namespace Bussines.Interface
{
    public interface IUserBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> GetById(int id);
        Task<User> Save(UserDto entity);
        Task Update(UserDto entity);
    }
}
