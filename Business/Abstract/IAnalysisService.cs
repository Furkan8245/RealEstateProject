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
    public interface IAnalysisService
    {
        IDataResult<AreaAnalysis> CalculateAndSave(AreaAnalysisDto areaAnalysisDto);

        IResult Delete(AreaAnalysisDeleteDto analysisDeleteDto);
        IResult Update(AreaAnalysisUpdateDto areaAnalysisUpdateDto);
        IDataResult<List<AreaAnalysis>> GetAll();
        IDataResult<AreaAnalysis> GetById(int id);
    }
}
