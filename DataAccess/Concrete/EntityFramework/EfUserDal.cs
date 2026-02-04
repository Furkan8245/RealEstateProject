using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RealEstateContext>, IUserDal
    {
        public EfUserDal(RealEstateContext context) : base(context)
        {
        }

        public List<OperationClaim> GelClaims(User user)
        {
            using(var context= new RealEstateContext())
            {
                var value = from o in context.OperationClaims
                            join u in context.UserOperationClaims
                            on o.Id equals u.OperationClaimId
                            where u.UserId == user.Id
                            select new OperationClaim { Id = o.Id, Name = o.Name };
                return value.ToList();
            }
        }
    }
}
