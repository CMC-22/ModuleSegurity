﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    public class StateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountriesId { get; set; }
        public string? CountriesName { get; set; }
    }
}
