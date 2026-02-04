using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Entities.Concrete
{
    public class PropertyType:IEntity
    {
        [Key]
        public int PropertyId { get; set; }
        public string PropertyName { get; set; } = string.Empty;
    }
}
