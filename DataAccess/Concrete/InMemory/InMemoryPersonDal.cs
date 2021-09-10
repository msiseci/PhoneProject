using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryPersonDal : IPersonDal
        {
        List<Person> _people;
        public InMemoryPersonDal()
        {
            //_people = new List<Person> {
            //  new Person { PersonId=1 , PersonName="Merve" , PersonSurname=" Siseci" , PhoneNumber=0536 , PersonMail="mervess@hotmail.com"},
            //  new Person { PersonId=2 , PersonName="Seda" , PersonSurname=" Yildirim" , PhoneNumber=0532, PersonMail="seda@hotmail.com"},
            //  new Person { PersonId=3,  PersonName="Serap" , PersonSurname=" Yilmaz" , PhoneNumber=053 , PersonMail="seraps@hotmail.com"},
            //  new Person { PersonId=4, PersonName="Özlem" , PersonSurname=" Demir" , PhoneNumber=053 , PersonMail="demirozlem@hotmail.com"},
            //  new Person { PersonId=5,  PersonName="Meltem" , PersonSurname=" Yildiz" , PhoneNumber=0534 , PersonMail="meltemm@hotmail.com"}
            //};
        }
        public void Add(Person person)
        {
            _people.Add(person);
        }

        public void Delete(Person person)
        {
            Person personToDelete = _people.SingleOrDefault(p => p.PersonId == person.PersonId);
            
           _people.Remove(person);
        }

        public List<Person> GetAll()
        {
            return _people;
        }


        public void Update(Person person)
        {
            Person personToUpdate = _people.SingleOrDefault(p => p.PersonId == person.PersonId);
            personToUpdate.PersonName = person.PersonName;
            personToUpdate.PersonSurname = person.PersonSurname;
            personToUpdate.PhoneNumber = person.PhoneNumber;
            personToUpdate.PersonMail = person.PersonMail;

        }

        public List<Person> GetAllByCategory(int personId)
        {

            return _people.Where(p => p.PersonId == personId).ToList();
        }

        public List<Person> GetAll(Expression<Func<Person, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Person Get(Expression<Func<Person, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<PersonDetailDto> GetPersonDetails()
        {
            throw new NotImplementedException();
        }
    }
}
