using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfNeighborhoodDal
        : EfEntityRepositoryBase<Neighborhood, RealEstateContext>,
          INeighborhoodDal
    {
        public EfNeighborhoodDal(RealEstateContext context)
            : base(context)
        {
        }
    }
}
