using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class DistrictValidator : AbstractValidator<District>
    {
        public DistrictValidator()
        {
            RuleFor(d => d.DistrictName).NotEmpty().WithMessage("İlçe adı boş bırakılamaz.");
            RuleFor(d => d.DistrictName).MinimumLength(1).WithMessage("İlçe adı en az 1 karakter olmalıdır.");
            RuleFor(d => d.CityId).GreaterThan(0).WithMessage("Lütfen geçerli bir şehir giriniz.");

        }
    }
}
