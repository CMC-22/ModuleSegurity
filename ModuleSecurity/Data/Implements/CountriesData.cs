﻿using Data.Interface;
using Entity.Context;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data.Implements
{
    public class CountriesData : ICountriesData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public CountriesData(ApplicationDBContext context, IConfiguration configuration)
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
            entity.DeleteAt = DateTime.Parse(DateTime.Today.ToString());
            context.Countries.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT Id, CONCAT(Name) AS TextoMostrar FROM Countries WHERE DeleteAt IS NULL ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Countries> GetById(int id)
        {
            try
            {
                var sql = @"SELECT * FROM Countries WHERE Id = @Id AND DeleteAt IS NULL ORDER BY Id ASC";
                Countries countries = await this.context.QueryFirstOrDefaulAsync<Countries>(sql, new { Id = id });
                return countries;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Countries> Save(Countries entity)
        {
            context.Countries.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Countries entity)
        {
            entity.UpdateAt = DateTime.Now;
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Countries> GetByName(string name)
        {
            return await this.context.Countries.AsNoTracking().Where(item => item.Name == name).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CountriesDto>> GetAll()
        {
            var sql = @"SELECT * FROM Countries Order BY Id ASC";
            return await this.context.QueryAsync<CountriesDto>(sql);
        }
    }
}

