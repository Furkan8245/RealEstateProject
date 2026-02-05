using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AreaAnalysisDto
    {
        public Geometry GeometryA;
        public Geometry GeometryB;
        public Geometry GeometryC;
        public string OperationType;
        public string Description;
    }
}
