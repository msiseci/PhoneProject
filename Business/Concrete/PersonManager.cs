using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonManager : IPersonService

    {
        IPersonDal  _personDal;
        
        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
            
        }


        [ValidationAspect(typeof(PersonValidator))]
        public IResult Add(Person person)
        {
            IResult result = BusinessRules.Run(CheckIfPhoneNumberExists(person.PhoneNumber));
              
            if(result != null)
            {
                return result;
            }

            
                _personDal.Add(person);
                return new SuccessResult(Messages.PersonAdded);
            
                     
        }

        public IResult Delete(int id)
        {
            var person = _personDal.Get(i => i.PersonId == id);
            _personDal.Delete(person);
            return new SuccessResult(Messages.PersonAdded);
        }

        public IDataResult<List<Person>> GetAll()
        {
            
           
            return new SuccessDataResult<List<Person>>(_personDal.GetAll(), Messages.PeopleListed);
        }

      
        public IDataResult<List<Person>> GetAllByPersonId(int id)
        {
            return new SuccessDataResult<List<Person>> (_personDal.GetAll(p => p.PersonId == id));
        }

        public IDataResult<Person> GetById(int personId)
        {
            return new SuccessDataResult<Person> (_personDal.Get(p=> p.PersonId == personId));
        }

        public IDataResult<List<PersonDetailDto>> GetPersonDetails()
        {
            return new SuccessDataResult<List<PersonDetailDto>> (_personDal.GetPersonDetails());
        }

        [ValidationAspect(typeof(PersonValidator))]
        public IResult Update(Person person)
        {
            IResult result = BusinessRules.Run(CheckIfPhoneNumberExists(person.PhoneNumber,person.PersonId));

            if (result != null)
            {
                return result;
            }


            _personDal.Update(person);
            return new SuccessResult(Messages.PersonAdded);
        }
        private IResult CheckIfPhoneNumberExists(string phoneNumber,int personId=0)
        {
            var query= _personDal.GetQuery(p => p.PhoneNumber == phoneNumber);

            if (personId!=0)
            {
                query= query.Where(i=>i.PersonId!=personId);

            }
            var result = query.Any();

            if (result)
            {
                return new ErrorResult(Messages.PhoneNumberAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
