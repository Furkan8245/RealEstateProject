using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRealEstateDal
        : EfEntityRepositoryBase<RealEstate, RealEstateContext>, IRealEstateDal
    {
        private readonly RealEstateContext _context;

        public EfRealEstateDal(RealEstateContext context) : base(context)
        {
            _context = context;
        }

        public List<RealEstate> GetByFilter(RealEstateFilterDto filter)
        {
            var query = _context.RealEstates.AsQueryable();

            if (filter.RealEstateId.HasValue)
                query = query.Where(r => r.RealEstateId == filter.RealEstateId.Value);

            if (filter.CityId.HasValue)
                query = query.Where(r => r.CityId == filter.CityId.Value);

            if (filter.DistrictId.HasValue)
                query = query.Where(r => r.DistrictId == filter.DistrictId.Value);

            if (!string.IsNullOrWhiteSpace(filter.ParcelNumber))
                query = query.Where(r => r.ParcelNumber == filter.ParcelNumber);

            if (!string.IsNullOrWhiteSpace(filter.LotNumber))
                query = query.Where(r => r.LotNumber == filter.LotNumber);

            return query.ToList();
        }
    }
}
