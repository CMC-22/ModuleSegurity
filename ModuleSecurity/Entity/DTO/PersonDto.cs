﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Email { get; set; }
        public string Addres {  get; set; }
        public string Type_document { get; set; }
        public int Document {  get; set; }
        public DateTime Birth_of_date { get; set; }
        public String Phone { get; set; }
        public bool State {  get; set; }
        public  int CityId { get; set; }
        public String? CityName {  get; set; } //propiedad de la tabla city
    }
}
