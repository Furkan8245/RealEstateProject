using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AreaAnalysisManager : IAnalysisService
    {
        private readonly IAreaAnalysisDal _areaAnalysisDal
public AreaAnalysisManager(IAreaAnalysisDal areaAnalysisDal)
        {
            _areaAnalysisDal = areaAnalysisDal;
        }

        public IDataResult<AreaAnalysis> CalculateAndSave(AreaAnalysisDto areaAnalysisDto)
        {
            Geometry resultGeometry = null;

            switch (areaAnalysisDto.OperationType)
            {
                case "A ∩ B":
                    resultGeometry = areaAnalysisDto.GeometryA.Intersection(areaAnalysisDto.GeometryB);
                    break;
                case "B ∩ A":
                    resultGeometry = areaAnalysisDto.GeometryB.Intersection(areaAnalysisDto.GeometryA);
                    break;
                case "A ∪ B":
                    resultGeometry = areaAnalysisDto.GeometryA.Union(areaAnalysisDto.GeometryB);
                    break;
                case "A ∪ B ∪ C":
                    var unionAB = areaAnalysisDto.GeometryA.Union(areaAnalysisDto.GeometryB);
                    resultGeometry = unionAB.Union(areaAnalysisDto.GeometryC);
                    break;
                default:
                    return new ErrorDataResult<AreaAnalysis>(Messages.OperationTypeArea);
            }
            if (resultGeometry == null || resultGeometry.IsEmpty)
                return new ErrorDataResult<AreaAnalysis>(Messages.AreaProcess);

            var analysisResult = new AreaAnalysis()
            {
                Name = areaAnalysisDto.Description ?? Messages.NewAnalysis,
                Geometry=resultGeometry,
                OperationType= areaAnalysisDto.OperationType,
                Area=resultGeometry.Area,
                CreatedDate=DateTime.Now
            };
            if (areaAnalysisDto.OperationType.Contains("∪"))
            {
                _areaAnalysisDal.Add(analysisResult);
                return new SuccessDataResult<AreaAnalysis>(analysisResult, Messages.SuccessAnalysis);

            }
            //If intersection (A ∩ B or B ∩ A) sadece sonucu döner,save olmaz
            return new SuccessDataResult<AreaAnalysis>(analysisResult, Messages.IntersectionNoSave);
        }

        public IResult Delete(int id)
        {
            var value = _areaAnalysisDal.Get(a => a.Id == id);
            if (value == null)
                return new ErrorResult(Messages.RecordNotFound);
            _areaAnalysisDal.Delete(value);
            return new SuccessResult(Messages.DeleteAnaliysis);
        }

        public IDataResult<List<AreaAnalysis>> GetAll()
        {
            return new SuccessDataResult<List<AreaAnalysis>>(_areaAnalysisDal.GetAll());
        }

        public IDataResult<AreaAnalysis> GetById(int id)
        {
            return new SuccessDataResult<AreaAnalysis>(_areaAnalysisDal.Get(a => a.Id == id));
        }

        public IResult Update(AreaAnalysisUpdateDto areaAnalysisUpdateDto)
        {
            var value = _areaAnalysisDal.Get(a => a.Id = areaAnalysisUpdateDto.Id);
            if (value == null)
                return new ErrorResult(Messages.RecordNotFound);
            value.Name = areaAnalysisUpdateDto.Name;
            value.Geometry = areaAnalysisUpdateDto.ResultGeo;
           _areaAnalysisDal.Update(value);
            return new SuccessResult(Messages.AreaAnalysisUpdate);
        }
    }
}
