using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class NeighborhoodManager : INeighborhoodService
    {
        INeighborhoodDal _neighborhoodDal;

        public NeighborhoodManager(INeighborhoodDal neighborhoodDal)
        {
            _neighborhoodDal = neighborhoodDal;
        }

        public IResult Add(Neighborhood neighborhood)
        {
            var value = new Neighborhood
            {
                NeighborhoodName = neighborhood.NeighborhoodName,
                DistrictId=neighborhood.DistrictId
            };
            _neighborhoodDal.Add(neighborhood);
            return new SuccessResult(Messages.NeighborhoodAdded);
        }

        public IResult Delete(int id)
        {
            var response = _neighborhoodDal.Get(n => n.NeighborhoodId == id);
            _neighborhoodDal.Delete(response);
            return new SuccessResult(Messages.NeighborhoodDeleted);
        }

        public IResult Exists(int id)
        {
            var response = _neighborhoodDal.Get(e => e.NeighborhoodId == id);
            if (response != null) return new SuccessResult();
            return new ErrorResult(Messages.NeighborhoodNotFound);
        }

        public IDataResult<List<Neighborhood>> GetAll()
        {
            return new SuccessDataResult<List<Neighborhood>>(_neighborhoodDal.GetAll(),Messages.NeighborhoodListed);
        }

        public IDataResult<List<Neighborhood>> GetAllByDistrictId(int districtId)
        {
            return new SuccessDataResult<List<Neighborhood>>(_neighborhoodDal.GetAll(n => n.DistrictId == districtId));
        }

        public IDataResult<Neighborhood> GetById(int neighborhoodId)
        {
            return new SuccessDataResult<Neighborhood>(_neighborhoodDal.Get(n => n.NeighborhoodId == neighborhoodId));
        }

        public IResult Update(Neighborhood neighborhood)
        {
            _neighborhoodDal.Update(neighborhood);
            return new SuccessResult(Messages.NeighborhoodUpdated);
        }
    }
}
