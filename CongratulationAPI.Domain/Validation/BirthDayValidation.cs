using CongratulationAPI.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongratulationAPI.Domain.Validation
{
    public class BirthDayValidation : AbstractValidator<User>, IBirthDayValidation
    {
        public BirthDayValidation()
        {
            RuleFor(User => User.Date).NotEmpty();
        }
    }
}
