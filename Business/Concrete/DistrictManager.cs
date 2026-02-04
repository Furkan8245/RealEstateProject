using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DistrictManager:IDistrictService
    {
        IDistrictDal _districtDal;

        public DistrictManager(IDistrictDal districtDal)
        {
            _districtDal = districtDal;
        }

        public IResult Add(District district)
        {
            _districtDal.Add(district);
            return new SuccessResult(Messages.DistrictAdded);
        }

        public IResult Delete(District district)
        {
            _districtDal.Delete(district);
            return new SuccessResult(Messages.DistrictDeleted);
        }

        public IResult Exists(int id)
        {
            var value = _districtDal.Get(d => d.DistrictId == id);
            if (value == null) return new SuccessResult();
            return new ErrorResult(Messages.DistrictNotFound);
        }

        public IDataResult<District> Get(Expression<Func<District, bool>> filter)
        {
            return new SuccessDataResult<District>(_districtDal.Get(filter));
        }

        public IDataResult<List<District>> GetAll(Expression<Func<District, bool>> filter = null)
        {
            return new SuccessDataResult<List<District>>(_districtDal.GetAll(filter), Messages.DistrictListed);
        }

        public IDataResult<District> GetById(int id)
        {
            return new SuccessDataResult<District>(_districtDal.Get(d => d.DistrictId == id));
        }

        public IResult Update(District district)
        {
            _districtDal.Update(district);
            return new SuccessResult(Messages.DistrictUpdated);
        }
    }
}
