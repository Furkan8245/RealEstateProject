using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using NetTopologySuite.Geometries;
using System;

namespace Business.Concrete
{
    public class RealEstateManager : IRealEstateService
    {
        private readonly IRealEstateDal _realEstateDal;
        private readonly IAuditLogDal _auditLogDal;
        private readonly GeometryFactory _geometryFactory;

        public RealEstateManager(IRealEstateDal realEstateDal, IAuditLogDal auditLogDal)
        {
            _realEstateDal = realEstateDal;
            _geometryFactory = new GeometryFactory(new PrecisionModel(), 4326);
            _auditLogDal = auditLogDal;
        }


        [CacheAspect]
        public IDataResult<List<RealEstate>> GetAll()
        {
            var result = _realEstateDal.GetAll();
            return new SuccessDataResult<List<RealEstate>>(result, Messages.RealEstateListed);
        }


        public IDataResult<List<RealEstate>> GetAllByUserId(int userId)
        {
            if (userId <= 0)
                return new ErrorDataResult<List<RealEstate>>("Geçersiz kullanıcı.");

            var result = _realEstateDal.GetAll(r => r.UserId == userId);

            return new SuccessDataResult<List<RealEstate>>(result, Messages.RealEstateListed);
        }

        public IDataResult<List<RealEstate>> GetAllByDistrictId(int districtId)
        {
            var result = _realEstateDal.GetAll(r => r.DistrictId == districtId);

            return new SuccessDataResult<List<RealEstate>>(result, Messages.RealEstateIdListed);
        }

        public IDataResult<List<RealEstate>> GetAllByNeighborhoodId(int neighborhoodId)
        {
            var result = _realEstateDal.GetAll(r => r.NeighborhoodId == neighborhoodId);

            return new SuccessDataResult<List<RealEstate>>(result, Messages.RealEstateNeighborIdListed);
        }

        public IDataResult<RealEstate> GetById(int id)
        {
            if (id <= 0)
                return new ErrorDataResult<RealEstate>("Geçersiz ID");

            var result = _realEstateDal.Get(r => r.RealEstateId == id);

            return result == null
                ? new ErrorDataResult<RealEstate>(Messages.NoRealEstate)
                : new SuccessDataResult<RealEstate>(result);
        }

        // ✅ Add
        [ValidationAspect(typeof(RealEstateValidator))]
        [CacheRemoveAspect("IRealEstateService.Get")]
        public IResult Add(RealEstateAddDto dto)
        {
            IResult ruleResult = BusinessRules.Run(
                CheckIfParcelAndIslandExist(dto.LotNumber, dto.ParcelNumber)
            );

            if (ruleResult != null)
                return ruleResult;

            var entity = new RealEstate
            {
                UserId = dto.OwnerId,
                CityId = dto.CityId,
                DistrictId = dto.DistrictId,
                NeighborhoodId = dto.NeighborhoodId,
                PropertyId = dto.PropertyTypeId,
                Area = dto.Area,
                CityName = dto.CityName,
                DistrictName = dto.DistrictName,
                NeighborhoodName = dto.NeighborhoodName,
                CreatedDate = dto.CreatedDate.ToUniversalTime(),
                PropertyName = dto.PropertyName,
                ParcelNumber = dto.ParcelNumber,
                LotNumber = dto.LotNumber,
                Location = _geometryFactory.CreatePoint(
                    new Coordinate(dto.CoordinateX, dto.CoordinateY))

                
            };

            _realEstateDal.Add(entity);

            _auditLogDal.Add(new AuditLog
            {
                UserId = dto.OwnerId,
                OperationType = "Taşınmaz Ekleme",
                Status = "Success",
                Description=$"{dto.CityName} / {dto.DistrictName} adresine eklendi.",
                TimeStamp = DateTime.Now.ToUniversalTime(),
                UserIp="127.0.0.1"
            });

            return new SuccessResult(Messages.RealEstateAdded);
        }


        [CacheRemoveAspect("IRealEstateService.Get")]
        public IResult Update(RealEstateUpdateDto dto)
        {
            
                var entity = _realEstateDal.Get(r => r.RealEstateId == dto.Id);

                if (entity == null)
                    return new ErrorResult(Messages.NoRealEstateUpdated);

                entity.CityId = dto.CityId;
                entity.DistrictId = dto.DistrictId;
                entity.NeighborhoodId = dto.NeighborhoodId;
                entity.ParcelNumber = dto.ParcelNumber;
                entity.LotNumber = dto.LotNumber;
                entity.PropertyId = dto.PropertyTypeId;
                entity.Area = dto.Area;
                entity.CityName = dto.CityName;
                entity.DistrictName = dto.DistrictName;
                entity.NeighborhoodName = dto.NeighborhoodName;
                entity.Location = _geometryFactory.CreatePoint(
                new Coordinate(dto.CoordinateX, dto.CoordinateY));

                _realEstateDal.Update(entity);

                return new SuccessResult(Messages.RealEstateUpdated);  
        }
        [CacheRemoveAspect("IRealEstateService.Get")]
        public IResult Delete(RealEstateDeleteDto dto)
        {
            var entity = _realEstateDal.Get(r => r.RealEstateId == dto.Id);

            if (entity == null)
                return new ErrorResult(Messages.NoRealEstate);

            _realEstateDal.Delete(entity);

            return new SuccessResult(Messages.RealEstateDeleted);
        }

 
        public IDataResult<List<RealEstate>> GetByFilter(RealEstateFilterDto filter)
        {
            var result = _realEstateDal.GetAll(r =>
                (filter.CityId == 0 || r.CityId == filter.CityId) &&
                (string.IsNullOrEmpty(filter.ParcelNumber) || r.ParcelNumber == filter.ParcelNumber)
            );

            return new SuccessDataResult<List<RealEstate>>(result);
        }


        private IResult CheckIfParcelAndIslandExist(string lot, string parcel)
        {
            bool exists = _realEstateDal
                .GetAll(r => r.LotNumber == lot && r.ParcelNumber == parcel)
                .Any();

            return exists
                ? new ErrorResult(Messages.IsThereParcelAndLotNumber)
                : new SuccessResult();
        }
    }
}
