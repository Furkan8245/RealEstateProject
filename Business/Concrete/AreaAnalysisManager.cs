using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.IdentityModel.Tokens;
using NetTopologySuite.Geometries;

namespace Business.Concrete
{
    public class AreaAnalysisManager : IAnalysisService
    {
        private readonly IAreaAnalysisDal _areaAnalysisDal;
        public AreaAnalysisManager(IAreaAnalysisDal areaAnalysisDal)
        {
            _areaAnalysisDal = areaAnalysisDal;
        }

        public IDataResult<AreaAnalysis> CalculateAndSave(AreaAnalysisDto areaAnalysisDto)
        {
            if (areaAnalysisDto.GeometryA == null || areaAnalysisDto.GeometryB == null ||
                areaAnalysisDto.GeometryC == null)
                return new ErrorDataResult<AreaAnalysis>(Messages.MissingProcess);
            areaAnalysisDto.GeometryA.SRID = areaAnalysisDto.GeometryB.SRID = areaAnalysisDto.GeometryC.SRID = 4326;
            Geometry resultGeo = null;
            bool isUnion = false;
            string name = areaAnalysisDto.Description ?? Messages.AnalysisMessage;
            switch (areaAnalysisDto.OperationType?.ToLower())
            {
                case "intersectionab":
                    resultGeo = areaAnalysisDto.GeometryA.Intersection(areaAnalysisDto.GeometryB);
                    break;
                case "intersectionba":
                    resultGeo = areaAnalysisDto.GeometryB.Intersection(areaAnalysisDto.GeometryA);
                    break;
                case "unionab":
                    resultGeo = areaAnalysisDto.GeometryA.Union(areaAnalysisDto.GeometryB);
                    isUnion = true;
                    name = Messages.UnionAB;
                    break;
                case "unionabc":
                    resultGeo = areaAnalysisDto.GeometryA.Union(areaAnalysisDto.GeometryB).Union(areaAnalysisDto.GeometryC);
                    isUnion = true;
                    name = Messages.UnionABC;
                    break;
                default:
                    return new ErrorDataResult<AreaAnalysis>(Messages.FalseProcess);

            }
            if (resultGeo == null || resultGeo.IsEmpty)
                return new ErrorDataResult<AreaAnalysis>(Messages.NoIntersection);
            double areaM2 = CalculaRealArea(resultGeo);
            var analysis = new AreaAnalysis
            {
                Name = name,
                Geometry = resultGeo,
                OperationType = areaAnalysisDto.OperationType,
                Area = Math.Round(areaM2, 2),
                Description = areaAnalysisDto.Description,
                CreatedDate = DateTime.UtcNow
            };
            if (isUnion)
            {
                _areaAnalysisDal.Add(analysis);
                return new SuccessDataResult<AreaAnalysis>(analysis, $"{name}" + Messages.SaveAnalysis);
            }
            return new SuccessDataResult<AreaAnalysis>(analysis, Messages.IntersectionResult);

            
        }
        private double CalculaRealArea(Geometry geo)
        {
            double lat = geo.Centroid.Y;
            double metersPerDegree = 111319.9;
            double cosLat = Math.Cos(lat * Math.PI / 180.0);
            return Math.Abs(geo.Area * Math.Pow(metersPerDegree, 2) * cosLat);
        }


        public IResult Delete(AreaAnalysisDeleteDto analysisDeleteDto)
        {
            var value = _areaAnalysisDal.Get(a => a.Id == analysisDeleteDto.Id);
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
            var value = _areaAnalysisDal.Get(a => a.Id == areaAnalysisUpdateDto.Id);
            if (value == null)
                return new ErrorResult(Messages.RecordNotFound);
            value.Description = areaAnalysisUpdateDto.Description;
            value.Name= areaAnalysisUpdateDto.Name;
            value.Geometry = areaAnalysisUpdateDto.ResultGeo;
           _areaAnalysisDal.Update(value);
            return new SuccessResult(Messages.AreaAnalysisUpdate);
        }
    }
}
