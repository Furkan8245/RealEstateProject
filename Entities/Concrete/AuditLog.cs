using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AuditLog:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string OperationType { get; set; }
        public string Description { get; set; }
        public string Status {  get; set; }
        public DateTime TimeStamp { get; set; }
        public string UserIp { get; set; }


    }
}
