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
    public class CityManager : ICityService
    {
        ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public IResult Add(City city)
        {
            _cityDal.Add(city);
            return new SuccessResult(Messages.CityAdded);
        }

        public IResult Delete(City city)
        {
            _cityDal.Delete(city);
            return new SuccessResult(Messages.CityDeleted);
        }

        public IResult Exists(int id)
        {
            var value = _cityDal.Get(c => c.CityId == id);
            if (value != null) return new SuccessResult();
            return new ErrorResult(Messages.CityNotFound);
        }

        public IDataResult<City> Get(Expression<Func<City, bool>> filter)
        {
            return new SuccessDataResult<City>(_cityDal.Get(filter));
        }

        public IDataResult<List<City>> GetAll(Expression<Func<City, bool>> filter = null)
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetAll(filter),Messages.CityListed);
        }

        public IDataResult<City> GetById(int id)
        {
            return new SuccessDataResult<City>(_cityDal.Get(c => c.CityId == id));
        }

        public IResult Update(City city)
        {
            _cityDal.Update(city);
            return new SuccessResult(Messages.CityUpdated);
        }
    }
}
