using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    public class UserRoleDto
    {
        public int Id { get; set; }
        public bool State {  get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }//propiedad de la tabla user
        public int RoleId { get; set; }
        public string RoleName { get; set; }//propiedad de la tabla role
    }
}
