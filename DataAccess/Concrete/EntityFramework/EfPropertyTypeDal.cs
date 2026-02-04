using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPropertyTypeDal
        : EfEntityRepositoryBase<PropertyType, RealEstateContext>,
          IPropertyTypeDal
    {
        public EfPropertyTypeDal(RealEstateContext context)
            : base(context)
        {
        }
    }
}
