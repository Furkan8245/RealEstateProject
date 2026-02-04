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
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class RealEstateManager : IRealEstateService
    {
        private readonly IRealEstateDal _realEstateDal;

        public RealEstateManager(IRealEstateDal realEstateDal)
        {
            _realEstateDal = realEstateDal;
        }

        [ValidationAspect(typeof(RealEstateValidator))]
        [CacheRemoveAspect("IRealEstateService.Get")]
        public IResult Add(RealEstateAddDto realEstateAddDto)
        {
          
            IResult result = BusinessRules.Run(
                CheckIfParcelAndIslandExist(realEstateAddDto.LotNumber, realEstateAddDto.ParcelNumber)
            );

            if (result != null) return result;

            var realEstate = new RealEstate
            {
                UserId = realEstateAddDto.OwnerId, 
                CityId = realEstateAddDto.CityId,
                DistrictId = realEstateAddDto.DistrictId,
                NeighborhoodId = realEstateAddDto.NeighborhoodId,
                PropertyId = realEstateAddDto.PropertyTypeId,
                ParcelNumber = realEstateAddDto.ParcelNumber,
                LotNumber = realEstateAddDto.LotNumber,
                Location = new NetTopologySuite.Geometries.Point(realEstateAddDto.CoordinateX,realEstateAddDto.CoordinateY)
                {
                    SRID=2436
                }
            };

            _realEstateDal.Add(realEstate);
            return new SuccessResult(Messages.RealEstateAdded);
        }

        [CacheRemoveAspect("IRealEstateService.Get")]
        public IResult Delete(RealEstateDeleteDto realEstateDeleteDto)
        {
            var isThere = _realEstateDal.Get(r => r.RealEstateId == realEstateDeleteDto.Id);
            if (isThere == null)
            {
                return new ErrorResult(Messages.NoRealEstate);
            }

            _realEstateDal.Delete(isThere);
            return new SuccessResult(Messages.RealEstateDeleted);
        }

        [CacheAspect]
        public IDataResult<List<RealEstate>> GetAll()
        {
            return new SuccessDataResult<List<RealEstate>>(_realEstateDal.GetAll(),Messages.RealEstateListed);
        }

        public IDataResult<List<RealEstate>> GetAllByDistrictId(int id)
        {
            return new SuccessDataResult<List<RealEstate>>(_realEstateDal.GetAll(r => r.DistrictId == id),Messages.RealEstateIdListed);
        }

        public IDataResult<List<RealEstate>> GetAllByNeighborhoodId(int id)
        {
            return new SuccessDataResult<List<RealEstate>>(_realEstateDal.GetAll(r => r.NeighborhoodId == id),Messages.RealEstateNeighborIdListed);
        }

        public IDataResult<RealEstate> GetById(int id)
        {
            var result = _realEstateDal.Get(r => r.RealEstateId == id);
            if (result == null) return new ErrorDataResult<RealEstate>(Messages.NoRealEstate);
            return new SuccessDataResult<RealEstate>(result);
        }

        public IResult Update(RealEstateUpdateDto realEstateUpdateDto)
        {
            var isThere = _realEstateDal.Get(r => r.RealEstateId == realEstateUpdateDto.Id);
            if (isThere == null) return new ErrorResult(Messages.NoRealEstateUpdated);

            isThere.CityId = realEstateUpdateDto.CityId;
            isThere.DistrictId = realEstateUpdateDto.DistrictId;
            isThere.NeighborhoodId = realEstateUpdateDto.NeighborhoodId;
            isThere.ParcelNumber = realEstateUpdateDto.ParcelNumber;
            isThere.LotNumber = realEstateUpdateDto.LotNumber;
            isThere.PropertyId = realEstateUpdateDto.PropertyTypeId;
            isThere.Location = new NetTopologySuite.Geometries.Point(realEstateUpdateDto.CoordinateX, realEstateUpdateDto.CoordinateY);

            _realEstateDal.Update(isThere);
            return new SuccessResult(Messages.RealEstateUpdated);
        }

        // Filtreleme mantığı 
        public IDataResult<List<RealEstate>> GetByFilter(RealEstateFilterDto filter)
        {
            var result = _realEstateDal.GetAll(r =>
                (filter.CityId == 0 || r.CityId == filter.CityId) &&
                (string.IsNullOrEmpty(filter.ParcelNumber) || r.ParcelNumber == filter.ParcelNumber)
            );
            return new SuccessDataResult<List<RealEstate>>(result);
        }

//Business Rules 
        private IResult CheckIfParcelAndIslandExist(string lot, string parcel)
        {
            var result = _realEstateDal.GetAll(r => r.LotNumber == lot && r.ParcelNumber == parcel).Any();
            if (result) return new ErrorResult(Messages.IsThereParcelAndLotNumber);
            return new SuccessResult();
        }
    }
}