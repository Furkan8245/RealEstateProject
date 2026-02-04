using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CityValidator : AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(c => c.CityName).NotEmpty().WithMessage("Şehir adı boş bırakılamaz.");
            RuleFor(c => c.CityName).MinimumLength(1).WithMessage("Şehir adı en az 1 karakter olmalıdır.");


        }
    }
}
