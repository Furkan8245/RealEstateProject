using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryRealStateDal : IRealEstateDal
    {
        List<RealEstate> _realEstates;
        public InMemoryRealStateDal()
        {
            _realEstates = new List<RealEstate> {
                new RealEstate{RealEstateId=1,UserId=1,PropertyId=1,NeighborhoodId=1,ParcelNumber="1234",LotNumber="5678"},
                new RealEstate{RealEstateId=2,UserId=2,PropertyId=2,NeighborhoodId=2,ParcelNumber="2234",LotNumber="6678"},
                new RealEstate{RealEstateId=3,UserId=3,PropertyId=3,NeighborhoodId=3,ParcelNumber="3234",LotNumber="7678"},
            };
        }
        public void Add(RealEstate realEstate)
        {
            _realEstates.Add(realEstate);
        }

        public void Delete(RealEstate realEstate)
        {
            RealEstate realEstateToDelete= realEstateToDelete=_realEstates.SingleOrDefault(p => p.RealEstateId == realEstate.RealEstateId);
            _realEstates.Remove(realEstateToDelete);

        }

        public List<RealEstate> GelAll()
        {
            return _realEstates;
        }

        public RealEstate Get(Expression<Func<RealEstate, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<RealEstate> GetAll(Expression<Func<RealEstate, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<RealEstate> GetAllByIdPropertyType(int PropertyId)
        {
            throw new NotImplementedException();
        }

        public List<RealEstate> GetByFilter(RealEstateFilterDto filter)
        {
            throw new NotImplementedException();
        }

        public List<RealEstateFilterDto> GetRealEstateFilters()
        {
            throw new NotImplementedException();
        }

        public void Update(RealEstate realEstate)
        {
            RealEstate realEstateUpdate = _realEstates.SingleOrDefault(p => p.RealEstateId == realEstate.RealEstateId);
            realEstateUpdate.DistrictId = realEstate.DistrictId;
            realEstateUpdate.PropertyId = realEstate.PropertyId;
            realEstateUpdate.NeighborhoodId = realEstate.NeighborhoodId;
            realEstateUpdate.ParcelNumber = realEstate.ParcelNumber;
            realEstateUpdate.LotNumber = realEstate.LotNumber;


        }
    }
}
