using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRealEstateService
    {
        
        IDataResult<List<RealEstate>> GetAll();

    
        IDataResult<List<RealEstate>> GetAllByUserId(int userId);


        IDataResult<List<RealEstate>> GetAllByDistrictId(int districtId);
        IDataResult<List<RealEstate>> GetAllByNeighborhoodId(int neighborhoodId);

        IDataResult<RealEstate> GetById(int id);
        
        IDataResult<List<RealEstate>> GetByFilter(RealEstateFilterDto filterDto);

        IResult Add(RealEstateAddDto dto);
        IResult Update(RealEstateUpdateDto dto);
        IResult Delete(RealEstateDeleteDto dto);
    }
}
