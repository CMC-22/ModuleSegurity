using Entity.DTO;
using Entity.Model.Security;
<<<<<<< HEAD
=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> 90d74f609e8c07d10b0c9772d81c5c5d745185e0

namespace Bussines.Interface
{
    public interface IViewBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<ViewDto>> GetAll();
        Task<ViewDto> GetById(int id);
        Task<View> Save(ViewDto entity);
        Task Update(ViewDto entity);
    }
}
