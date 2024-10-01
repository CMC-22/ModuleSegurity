using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    public class RoleViewDto
    {
        public int Id { get; set; }
        public bool State {  get; set; }

        public int ViewId { get; set; }
        public string ? ViewName { get; set; } //propiedad de la tabla view
        public int RoleId { get; set; }
        public string ? RoleName { get; set; }//propieda de la tabla role
    }
}
