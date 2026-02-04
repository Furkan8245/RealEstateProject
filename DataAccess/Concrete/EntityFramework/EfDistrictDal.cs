using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDistrictDal
        : EfEntityRepositoryBase<District, RealEstateContext>,
          IDistrictDal
    {
        public EfDistrictDal(RealEstateContext context)
            : base(context)
        {
        }
    }
}
