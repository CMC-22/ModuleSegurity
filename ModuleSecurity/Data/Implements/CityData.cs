using Data.Interface;
using Entity.Context;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data.Implements
{
    public class CityData : ICityData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public CityData(ApplicationDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task Delete(int Id, bool isSoftDelete = true)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            if (isSoftDelete)
            { 
            //ELIMINACION LOGICO    
            entity.DeleteAt = DateTime.Today;
            context.Citys.Update(entity);
        }
        else
        {
        context.Citys.Remove(entity);
        }
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT Id, CONCAT(Name, '-', Postalcode, '-', StateId) AS TextoMostrar FROM citys WHERE DeleteAt IS NULL AND State = 1 ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<City> GetById(int id)
        {
            var sql = @"SELECT * FROM citys WHERE Id = @Id AND DeleteAt IS NULL ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaulAsync<City>(sql, new { Id = id });
        }

        public async Task<City> Save(City entity)
        {
            context.Citys.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(City entity)
        {
            entity.UpdateAt = DateTime.Now;
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<City> GetByName(string name)
        {
            return await this.context.Citys.AsNoTracking().Where(item => item.Name == name).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CityDto>> GetAll()
        {
            var sql = @"SELECT c.Id, c.Name, c.PostalCode, c.StateId, s.Name AS State FROM citys AS c INNER JOIN State AS s ON s.Id = c.StateId WHERE ISNULL(c.DeleteAt)";
            return await context.QueryAsync<CityDto>(sql);
        }
    }
}

