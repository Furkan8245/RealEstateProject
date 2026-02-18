using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IRealEstateDal : IEntityRepository<RealEstate>
    {
        List<RealEstate> GetByFilter(RealEstateFilterDto filter);
    }
}
