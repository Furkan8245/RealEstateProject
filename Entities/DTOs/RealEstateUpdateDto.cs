using Core.Entities;

namespace Entities.DTOs
{
    public class RealEstateUpdateDto:IDto
    {
        public int Id { get; set; }
        public int CityId { get; set; } 
        public int DistrictId { get; set; }
        public int NeighborhoodId { get; set; }
        public string ParcelNumber { get; set; } // Ada
        public string LotNumber { get; set; }    // Parsel
        public string CityName { get; set; }
        public string DistrictName{ get; set; }
        public string NeighborhoodName{ get; set; }
        public int PropertyTypeId { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public double Area { get; set; }
        public string PropertyName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
