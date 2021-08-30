using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class PersonValidator : AbstractValidator <Person>
    {
        public PersonValidator()
        {
            RuleFor(p => p.PersonName).NotEmpty();
            RuleFor(p => p.PersonName).MinimumLength(1);
            RuleFor(p => p.PhoneNumber).NotEmpty();
            RuleFor(p => p.PersonName).Must(StartWithA);
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
