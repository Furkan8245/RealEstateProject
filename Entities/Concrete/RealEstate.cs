using Core.Entities;
using NetTopologySuite.Geometries;

namespace Entities.Concrete  
{
    public class RealEstate :IEntity
    {
        public int RealEstateId { get; set; }
        public int UserId { get; set; }
        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public string NeighborhoodName { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int PropertyId { get; set; }
        public int NeighborhoodId { get; set; }
        public string ParcelNumber { get; set; } = string.Empty;
        public string? LotNumber { get; set; }
        public Point Location { get; set; }
        public double Area { get; set; }
        public string PropertyName { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.UtcNow;
    }
}