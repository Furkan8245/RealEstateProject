using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class PropertyTypeValidator : AbstractValidator<PropertyType>
    {
        public PropertyTypeValidator()
        {
            RuleFor(p => p.PropertyName).NotEmpty().WithMessage("Emlak tipi adı boş bırakılamaz.");
            RuleFor(p => p.PropertyName).MinimumLength(1).WithMessage("Emlak tipi adı en az 1 karakter olmalıdır."); 
        }
    }
}
