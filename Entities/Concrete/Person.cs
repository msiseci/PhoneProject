using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class Person: IEntity

    {
        public int PersonId { get; set; }

        public string PersonName { get; set; }

        public string PersonSurname { get; set; }

        public string PhoneNumber { get; set; }

        public string PersonMail  { get; set; }

        

    }
}
