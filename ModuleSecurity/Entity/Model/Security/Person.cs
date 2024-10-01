using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class Person
    {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Email { get; set; }
        public string Addres { get; set; }
        public string Type_document { get; set; }
        public int Document { get; set; }
        public DateTime Birth_of_date { get; set; }
        public DateTime CreateAt { get; set; }
<<<<<<< HEAD
        public DateTime ? UpdateAt { get; set; }
        public DateTime ? DeleteAt { get; set; }
        public int Phone { get; set; }
=======
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
        public String Phone { get; set; }
>>>>>>> 90d74f609e8c07d10b0c9772d81c5c5d745185e0
        public bool State {  get; set; }
       
        //Asociaciones
        public int CityId {  get; set; }
        public City City { get; set; }
    }
}
