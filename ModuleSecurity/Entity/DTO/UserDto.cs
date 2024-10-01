using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool State {  get; set; }

        public int PersonId { get; set; } //propiedad de la tabla de person
        public string ? PersonName { get; set; }

    }
}
