using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class NeighborhoodValidator : AbstractValidator<Neighborhood>
    {
        public NeighborhoodValidator()
        {
            RuleFor(n => n.NeighborhoodName).NotEmpty().WithMessage("Mahalle adı boş bırakılamaz.");
            RuleFor(n => n.NeighborhoodName).MinimumLength(1).WithMessage("Mahalle adı en az 1 karakter olmalıdır.");
            RuleFor(n => n.DistrictId).GreaterThan(0).WithMessage("Lütfen geçerli bir ilçe giriniz.");
        }
    }
}
