using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCityDal
        : EfEntityRepositoryBase<City, RealEstateContext>,
          ICityDal
    {
        public EfCityDal(RealEstateContext context)
            : base(context)
        {
        }
    }
}
