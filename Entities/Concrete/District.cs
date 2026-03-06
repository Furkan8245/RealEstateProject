using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    [Table("districts")]
    public class District:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int DistrictId { get; set; }
        [Column("name")]
        public string DistrictName { get; set; } = string.Empty;
        [Column("city_id")]
        public int CityId { get; set; }


    }
}
