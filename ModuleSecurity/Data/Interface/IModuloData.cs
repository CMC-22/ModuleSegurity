﻿using Entity.DTO;
using Entity.Model.Security;


namespace Data.Interface
{
    public interface IModuloData
    {
        Task Delete(int id, bool isSoftDelete = true);
        Task<IEnumerable<ModuloDto>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Modulo> GetById(int id);
        Task<Modulo> Save(Modulo entity);
        Task Update(Modulo entity);
        Task<Modulo> GetByName(string description);
    }
}
