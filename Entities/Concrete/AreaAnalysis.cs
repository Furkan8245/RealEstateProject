using Core.Entities;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AreaAnalysis:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Geometry Geometry { get; set; }
        public double Area { get; set; }
        public string OperationType { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
