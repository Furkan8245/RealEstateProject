using Core.Entities;
using NetTopologySuite.Geometries;

namespace Entities.Concrete  
{
    public class RealEstate :IEntity
    {
        public int RealEstateId { get; set; }
        public int UserId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int PropertyId { get; set; }
        public int NeighborhoodId { get; set; }
        public string ParcelNumber { get; set; } = string.Empty;
        public string? LotNumber { get; set; }
        public Point Location { get; set; }
    }
}