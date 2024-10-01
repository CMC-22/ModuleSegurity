using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IUserData
    {
        Task Delete(int id, bool isSoftDelete = true);
        Task<IEnumerable<UserDto>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<User> GetById(int id);
        Task<User> Save(User user);
        Task Update(User user);
        Task<User> GetByName(string username);
    }
}
