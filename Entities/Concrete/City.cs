using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    [Table("cities")]
    public class City:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int CityId { get; set; }
        [Column("name")]
        public string CityName { get; set; } = string.Empty;
        [Column("plate_number")]
        public int PlateNumber { get; set; }
    }
}
