using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRealEstateDal : EfEntityRepositoryBase<RealEstate, RealEstateContext>, IRealEstateDal
    {
        private readonly RealEstateContext _context;

        public EfRealEstateDal(RealEstateContext context):base(context)
        {
            _context = context;
        }

        public List<RealEstate> GetByFilter(RealEstateFilterDto filter)
        {
            var query = _context.RealEstates.AsQueryable();
            if (filter.RealEstateId.HasValue)
                query = query.Where(r => r.RealEstateId == filter.RealEstateId);
            if (filter.CityId.HasValue)
                query = query.Where(r => r.CityId == filter.CityId);
            if (filter.DistrictId.HasValue)
                query = query.Where(r => r.DistrictId == filter.DistrictId);
            if (!string.IsNullOrEmpty(filter.ParcelNumber))
                query = query.Where(r => r.ParcelNumber == filter.ParcelNumber);
            if (!string.IsNullOrEmpty(filter.LotNumber))
                query = query.Where(r => r.LotNumber == filter.LotNumber);
            return query.ToList();
        }
    }
}
