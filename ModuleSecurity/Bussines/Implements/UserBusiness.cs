﻿

using Bussines.Interface;
using Data.Interface;
using Entity.DTO;
using Entity.Model.Security;

namespace Bussines.Implements
{
    public class UserBusiness : IUserBusiness
    {
        protected readonly IUserData data;

        public UserBusiness(IUserData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            IEnumerable<User> users = (IEnumerable<User>)await this.data.GetAll();
            var userDtos = users.Select(user => new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                State = user.State,
                PersonId = user.PersonId,
                PersonName = user.Person?.First_name,
            });
            return userDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

        public async Task<UserDto> GetById(int id)
        {
            User user = await this.data.GetById(id);
            UserDto userDto = new UserDto();

            userDto.Id = user.Id;
            userDto.Username = user.Username;
            userDto.Password = user.Password;
            userDto.State = user.State;
            userDto.PersonId = user.PersonId;

            return userDto;
        }

        public User MapearDatos(User user, UserDto entity)
        {
            user.Id = entity.Id;
            user.Username = entity.Username;
            user.Password = entity.Password;
            user.State = entity.State;
            user.PersonId = entity.PersonId;
            return user;
        }

        public async Task<User> Save(UserDto entity)
        {
            User user = new User();
            user.CreateAt = DateTime.Now.AddHours(-5);
            user = this.MapearDatos(user, entity);
            return await this.data.Save(user);
        }
        public async Task Update(UserDto entity)
        {
            User user = await this.data.GetById(entity.Id);
            if (user == null)
            {
                throw new Exception("Registro no encontrado");
            }

            user = this.MapearDatos(user, entity);
            await this.data.Update(user);
        }
    }
}

