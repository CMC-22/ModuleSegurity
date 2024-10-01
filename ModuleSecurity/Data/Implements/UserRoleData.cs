using Data.Interface;
using Entity.Context;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implements
{
    public class UserRoleData : IUserRoleData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public UserRoleData(ApplicationDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task Delete(int id, bool isSoftDelete = true)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            if (isSoftDelete)
            {
                //Eliminación lógica
                entity.DeleteAt = DateTime.Now;
                context.UseRoles.Update(entity);
            }
            else
            {
                context.UseRoles.Remove(entity);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT Id, CONCAT(Name, '-', Description) AS TextoMostrar FROM UserRole WHERE DeleteAt IS NULL ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<UserRole> GetById(int id)
        {
            var sql = @"SELECT * FROM UserRole WHERE Id = @Id AND DeleteAt IS NULL ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaulAsync<UserRole>(sql, new { Id = id });
        }

        public async Task<UserRole> Save(UserRole entity)
        {
            context.UseRoles.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(UserRole entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<UserRole> GetByName(int id)
        {
            return await this.context.UseRoles.AsNoTracking().Where(item => item.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UserRoleDto>> GetAll()
        {
            var sql = @"SELECT ur.*, u.Name AS UserName, r.Name AS RoleName
                        FROM userRoles ur INNER JOIN users u ON ur.UserId = u.Id
                                          INNER JOIN roles r ON ur.RoleId = r.Id   Order BY Id ASC";
            var userRoles = await this.context.QueryAsync<UserRoleDto>(sql);
            return userRoles;
        }
    }
}
