using Data.Interface;
using Entity.Context;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data.Implements
{
    public class ModuloData : IModuloData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public ModuloData(ApplicationDBContext context, IConfiguration configuration)
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
                context.Modulos.Update(entity);
            }
            else
            {
                context.Modulos.Remove(entity);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT Id, CONCAT(Name, '-', Description) AS TextoMostrar FROM Modulo WHERE DeleteAt IS NULL AND State = 1 ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Modulo> GetById(int id)
        {
            var sql = @"SELECT * FROM Modulo WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaulAsync<Modulo>(sql, new { Id = id });
        }

        public async Task<Modulo> Save(Modulo entity)
        {
            context.Modulos.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Modulo entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Modulo> GetByName(string description)
        {
            return await this.context.Modulos.AsNoTracking().Where(item => item.Description == description).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ModuloDto>> GetAll()
        {
            var sql = @"SELECT * FROM Modulo Order BY Id ASC";
            return await this.context.QueryAsync<ModuloDto>(sql);
        }
    }
}

