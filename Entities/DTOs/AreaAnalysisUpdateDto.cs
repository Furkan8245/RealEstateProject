using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AreaAnalysisUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Geometry ResultGeo { get; set; }
    }
}
