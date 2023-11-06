﻿using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator :AbstractValidator<Car>
    {
        public CarValidator() 
        {
            RuleFor(c=>c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(10).WithMessage(Messages.DailyPriceError);
            RuleFor(c=>c.Name).NotEmpty();
            
        }
    }
}
