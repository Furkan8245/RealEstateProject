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
    public interface IDistrictService
    {
        IResult Add(District district);
        IResult Update(District district);
        IResult Delete(District district);
        IDataResult<District> Get(Expression<Func<District, bool>> filter);
        IDataResult<District> GetById(int id);
        IDataResult<List<District>> GetAll(Expression<Func<District, bool>> filter = null);
        IResult Exists(int id);
    }
}
