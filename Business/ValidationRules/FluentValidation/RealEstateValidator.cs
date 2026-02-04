using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RealEstateValidator : AbstractValidator<RealEstate>
    {
        public RealEstateValidator()
        {
            RuleFor(r => r.LotNumber).NotEmpty().WithMessage("Ada numarası boş bırakılamaz.");
            RuleFor(r => r.ParcelNumber).NotEmpty().WithMessage("Parsel no boş olamaz.");

            RuleFor(r => r.NeighborhoodId).GreaterThan(0).WithMessage("Lütfen geçerli bir mahalle giriniz.");
            RuleFor(r => r.Location).NotEmpty().WithMessage("Lütfen haritadan taşınmazın konumunu işsretletiniz. ");

            RuleFor(r => r.PropertyId).NotEmpty().WithMessage("Taşınmazın tipini belirtiniz.");

            
        }
    }
}
