
using Bussines.Interface;
using Data.Interface;
using Entity.DTO;
using Entity.Model.Security;
using System.Data;

namespace Bussines.Implements
{
    public class PersonBusiness: IPersonBusiness
    {
            protected readonly IPersonData data;

            public PersonBusiness(IPersonData data)
            {
                this.data = data;
            }

            public async Task Delete(int id)
            {
                await this.data.Delete(id);
            }

            public async Task<IEnumerable<PersonDto>> GetAll()
            {
                IEnumerable<Person> persons = (IEnumerable<Person>) await this.data.GetAll();
                var personDtos = persons.Select(person => new PersonDto
                {
                    Id = person.Id,
                    First_name = person.First_name,
                    Last_name = person.Last_name,
                    Email = person.Email,
                    Addres = person.Addres,
                    Type_document = person.Type_document,
                    Document = person.Document,
                    Birth_of_date = person.Birth_of_date,
                    Phone = person.Phone,
                    CityId = person.CityId,
                    CityName = person.City?.Name
                });
                return personDtos;
            }

            public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
            {
                return await this.data.GetAllSelect();
            }

            public async Task<PersonDto> GetById(int id)
            {
                Person person = await this.data.GetById(id);
                PersonDto personDto = new PersonDto();
                personDto.Id = person.Id;
                personDto.First_name = person.First_name;
                personDto.Last_name = person.Last_name;
                personDto.Email = person.Email;
                personDto.Addres = person.Addres;
                personDto.Type_document = person.Type_document;
                personDto.Document = person.Document;
                personDto.Birth_of_date = person.Birth_of_date;
                personDto.Phone = person.Phone;
                personDto.CityId = person.CityId;
                return personDto;
            }

            public Person MapearDatos(Person person, PersonDto entity)
            {
                person.Id = entity.Id;
                person.First_name = entity.First_name;
                person.Last_name = entity.Last_name;
                person.Email = entity.Email;
                person.Addres = entity.Addres;
                person.Type_document = entity.Type_document;
                person.Document = entity.Document;
                person.Birth_of_date = entity.Birth_of_date;
                person.Phone = entity.Phone;
                person.CityId = entity.CityId;
                return person;
            }

        public async Task<Person> Save(PersonDto entity)
        {
            Person person = new Person
            {
                CreateAt = DateTime.Now.AddHours(-5)
            };
            person = this.MapearDatos(person, entity);
            return await this.data.Save(person);

        }

        public async Task Update(PersonDto entity)
            {
                Person person = await this.data.GetById(entity.Id);
                if (person == null)
                {
                    throw new Exception("Registro no encontrado");
                }
                person = this.MapearDatos(person, entity);
                await this.data.Update(person);
        }
    }
}
