using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    [Table("neighborhoods")]
    public class Neighborhood:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int NeighborhoodId { get; set; }
        [Column("name")]
        public string NeighborhoodName { get; set; } = string.Empty;
        [Column("district_id")]
        public int DistrictId { get; set; }


    }
}
