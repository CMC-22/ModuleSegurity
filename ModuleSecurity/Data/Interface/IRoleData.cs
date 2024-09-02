using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IRoleData
    {
        Task Delete(int id);
        Task<Role> GetById(int id);
        Task<Role> Save(Role entity);
        Task<IEnumerable<Role>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task Update(Role entity);
        Task<Role> GetByName(string name);
    }
}
