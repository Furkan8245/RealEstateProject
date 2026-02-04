using Core.Entities;

namespace Entities.Concrete
{
    public class Neighborhood:IEntity
    {
        public int NeighborhoodId { get; set; }
        public string NeighborhoodName { get; set; } = string.Empty;
        public int DistrictId { get; set; }


    }
}
