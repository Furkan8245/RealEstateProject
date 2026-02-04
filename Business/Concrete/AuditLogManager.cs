using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuditLogManager : IAuditLogService
    {
        IAuditLogDal _auditLogDal;

        public AuditLogManager(IAuditLogDal auditLogDal)
        {
            _auditLogDal = auditLogDal;
        }

        public IResult Add(AuditLog auditLog)
        {
            _auditLogDal.Add(auditLog);
            return new SuccessResult();
        }

        public IDataResult<List<AuditLog>> GetFilteredLogs(int? userId, string status, string operationType)
        {
            var result = _auditLogDal.GetAll(l => !userId.HasValue || l.UserId == userId
            && (string.IsNullOrEmpty(status) || l.Status == status) && (string.IsNullOrEmpty(operationType) || l.OperationType == operationType));
            if (result.Count == 0)
                return new ErrorDataResult<List<AuditLog>>(null, Messages.AuditLogError);

            return new SuccessDataResult<List<AuditLog>>(result);
        }
    }
}
