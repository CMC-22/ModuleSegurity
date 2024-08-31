using Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IModuloData
    {
        Task Delete(int id);
       
        Task<IEnumerable<ModuloDto>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<ModuloDto> GetById(int id);
        Task<ModuloDto> Save(ModuloDto entity);
        Task<ModuloDto> Update(ModuloDto entity);
    }
}
