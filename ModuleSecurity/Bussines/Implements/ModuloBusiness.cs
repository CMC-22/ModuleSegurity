﻿
using Bussines.Interface;
using Data.Interface;
using Entity.DTO;
using Entity.Model.Security;

namespace Business.Implements
{
    public class ModuloBusiness : IModuloBusiness
    {
        protected readonly IModuloData data;

        public ModuloBusiness(IModuloData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<ModuloDto>> GetAll()
        {
            IEnumerable<Modulo> modulos = (IEnumerable<Modulo>)await this.data.GetAll();
            var moduloDtos = modulos.Select(modulo => new ModuloDto
            {
                Id = modulo.Id,
                Description = modulo.Description,
                State = modulo.State
            });
            return moduloDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

        public async Task<ModuloDto> GetById(int id)
        {
            Modulo modulo = await this.data.GetById(id);
            ModuloDto moduloDto = new ModuloDto();

            moduloDto.Id = modulo.Id;
            moduloDto.Description = modulo.Description;
            moduloDto.State = modulo.State;
            return moduloDto;
        }

        public Modulo MapearDatos(Modulo modulo, ModuloDto entity)
        {
            modulo.Id = entity.Id;
            modulo.Description = entity.Description;
            modulo.State = entity.State;
            return modulo;
        }

        public async Task<Modulo> Save(ModuloDto entity)
        {
            Modulo modulo = new Modulo();
            modulo.CreateAt = DateTime.Now.AddHours(-5);
            modulo = this.MapearDatos(modulo, entity);
            return await this.data.Save(modulo);

        }

        public async Task Update(ModuloDto entity)
        {
            Modulo modulo = await this.data.GetById(entity.Id);
            if (modulo == null)
            {
                throw new Exception("Registro no encontrado");
            }
            modulo = this.MapearDatos(modulo, entity);
            await this.data.Update(modulo);
        }
    }
}

