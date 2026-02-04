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
    public interface INeighborhoodService
    {
        IDataResult<List<Neighborhood>> GetAll();
        IDataResult<Neighborhood> GetById(int neighborhoodId);
        IDataResult<List<Neighborhood>> GetAllByDistrictId(int districtId);
        IResult Add(Neighborhood neighborhood);
        IResult Update(Neighborhood neighborhood);
        IResult Delete(int id);
        IResult Exists(int id);




    }
}
