using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CCS
{
    public class DatabaseLogger : ILogger
    {
        private readonly IAuditLogService _auditLogService;

        public DatabaseLogger(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService;
        }

        public void Log(int userId, string status, string operationType, string desc, string ip)
        {
            _auditLogService.Add(new AuditLog
            {
                UserId = userId,
                Status = status,
                OperationType = operationType,
                Description = desc,
                UserIp = ip,
                TimeStamp = DateTime.Now
            });
        }
    }
}
