using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPersonDal : EfEntityRepositoryBase<Person, NorthwindContext>, IPersonDal

    {
        public List<PersonDetailDto> GetPersonDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.People
                             select new PersonDetailDto
                             {
                                 PersonId = p.PersonId,
                                 PersonName = p.PersonName,
                                 PersonSurname = p.PersonSurname,
                                 PersonMail = p.PersonMail
                             };
                return result.ToList();
            }
        }
    }
}
