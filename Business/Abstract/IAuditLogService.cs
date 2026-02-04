using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuditLogService
    {
        IResult Add(AuditLog auditLog);
        IDataResult<List<AuditLog>> GetFilteredLogs(int? userId, string status, string operationType);
    }
}
