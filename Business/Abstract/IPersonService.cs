using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public interface IPersonService
    {
        IDataResult<List<Person>> GetAll();
        IDataResult<List<Person>> GetAllByPersonId(int id);

        IDataResult<List<PersonDetailDto>>  GetPersonDetails();

        IDataResult<Person>GetById(int personId);

        IResult Add(Person person);

        IResult Update(Person person);




    }
}
