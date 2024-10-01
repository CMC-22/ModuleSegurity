using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Postalcode { get; set; }

        public int StateId { get; set; }
        public string ? StateName { get; set; } //propiedad de la tabla city
    }
}
