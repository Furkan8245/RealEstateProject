using Core.Entities;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Table("areaanalysis")]
    public class AreaAnalysis:IEntity
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Geometry")]
        public Geometry Geometry { get; set; }
        [Column("Area")]
        public double Area { get; set; }
        [Column("OperationType")]
        public string OperationType { get; set; }
        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }
        [Column("Description")]
        public string Description { get; set; }

    }
}
