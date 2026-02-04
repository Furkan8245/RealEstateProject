using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICityService
    {
        IResult Add(City city);
        IResult Update(City city);
        IResult Delete(City city);
        IDataResult<City> Get(Expression<Func<City, bool>> filter);
        IDataResult<City> GetById(int id);
        IDataResult<List<City>> GetAll(Expression<Func<City, bool>> filter = null);
        IResult Exists(int id);

    }
}
