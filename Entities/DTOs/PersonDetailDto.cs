using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
   public class PersonDetailDto :IDto
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }

        public string PersonSurname { get; set; }

        public int MyProperty { get; set; }

        public string PhoneNumber { get; set; }

        public string PersonMail { get; set; }

    }
}
