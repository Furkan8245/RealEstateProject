using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRealEstateService
    {

        IDataResult<List<RealEstate>> GetAllByNeighborhoodId(int id);
        IDataResult<List<RealEstate>> GetAllByDistrictId(int id);
        IDataResult<RealEstate> GetById(int id);
        IDataResult<List<RealEstate>> GetAllByUserId(int userId);

        IResult Add(RealEstateAddDto realEstateAddDto);
        IResult Update(RealEstateUpdateDto realEstateUpdateDto);
        IResult Delete(RealEstateDeleteDto realEstateDeleteDto);

        IDataResult<List<RealEstate>> GetByFilter(RealEstateFilterDto realEstateFilterDto);

        IDataResult<List<RealEstate>> GetAllByRole(int userId, string role);
    }
}
