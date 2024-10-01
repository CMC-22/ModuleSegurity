using Bussines.Interface;
using Data.Interface;
using Entity.DTO;
using Entity.Model.Security;


namespace Bussines.Implements
{
    public class UserRoleBusiness : IUserRoleBusiness
    {
        protected readonly IUserRoleData data;

        public UserRoleBusiness(IUserRoleData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<UserRoleDto>> GetAll()
        {
            IEnumerable<UserRole> userRoles = (IEnumerable<UserRole>)await this.data.GetAll();
            var userRoleDtos = userRoles.Select(userRole => new UserRoleDto
            {
                Id = userRole.Id,
                State = userRole.State,
                UserId = userRole.UserId,
                UserName = userRole.User?.Username
            });
            return userRoleDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

        public async Task<UserRoleDto> GetById(int id)
        {
            UserRole userRole = await this.data.GetById(id);
            UserRoleDto userRoleDto = new UserRoleDto();

            userRoleDto.Id = userRole.Id;
            userRoleDto.State = userRole.State;
            userRoleDto.UserId = userRole.UserId;

            return userRoleDto;
        }

        public UserRole MapearDatos(UserRole userRole, UserRoleDto entity)
        {
            userRole.Id = entity.Id;
            userRole.State = entity.State;
            return userRole;
        }

        public async Task<UserRole> Save(UserRoleDto entity)
        {
            UserRole userRole = new UserRole();
            userRole.CreateAt = DateTime.Now.AddHours(-5);
            userRole = this.MapearDatos(userRole, entity);
            return await this.data.Save(userRole);
        }
        public async Task Update(UserRoleDto entity)
        {
            UserRole userRole = await this.data.GetById(entity.Id);
            if (userRole == null)
            {
                throw new Exception("Registro no encontrado");
            }

            userRole = this.MapearDatos(userRole, entity);
            await this.data.Update(userRole);
        }
    }
}
