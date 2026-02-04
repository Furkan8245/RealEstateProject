using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class NeighborhoodManager : INeighborhoodService
    {
        private readonly INeighborhoodDal _neighborhoodDal;

        public NeighborhoodManager(INeighborhoodDal neighborhoodDal)
        {
            _neighborhoodDal = neighborhoodDal;
        }

        public IResult Add(NeighborhoodAddDto neighborhoodAddDto)
        {
            var neighborhood = new Neighborhood
            {
                NeighborhoodName = neighborhoodAddDto.Name,
                DistrictId=neighborhoodAddDto.DistrictId
            };
            _neighborhoodDal.Add(neighborhood);
            return new SuccessResult("Mahalle başarıyla eklendi");
        }

        public IResult Delete(NeighborhoodDeleteDto neighborhoodDeleteDto)
        {
            var response = _neighborhoodDal.Get(n => n.NeighborhoodId == neighborhoodDeleteDto.Id);
            if (response == null)
                return new ErrorResult("Silmek istediğiniz mahalle bulunamadı.");
            _neighborhoodDal.Delete(response);
            return new SuccessResult("Mahalle silindi.");
        }

        public IDataResult<List<Neighborhood>> GetAll()
        {
            return new SuccessDataResult<List<Neighborhood>>(_neighborhoodDal.GetAll(),"Mahalleler listelendi");
        }

        public IDataResult<List<Neighborhood>> GetAllByDistrictId(int districtId)
        {
            return new SuccessDataResult<List<Neighborhood>>(_neighborhoodDal.GetAll(n => n.DistrictId == districtId));
        }

        public IDataResult<Neighborhood> GetById(int neighborhoodId)
        {
            return new SuccessDataResult<Neighborhood>(_neighborhoodDal.Get(n => n.NeighborhoodId == neighborhoodId));
        }

        public IResult Update(NeighborhoodUpdateDto neighborhoodUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
