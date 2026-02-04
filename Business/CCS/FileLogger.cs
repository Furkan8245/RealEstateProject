using Business.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CCS
{
    public class FileLogger : ILogger
    {
        public void Log(int userId, string status, string operationType, string desc, string ip)
        {
            Console.WriteLine(Messages.FileLogMessage,$"{DateTime.Now} | User:{userId} | Status:{status} " +
                $"| Operation Type: {operationType} |" +
                $"Description:{desc} | IP:{ip}");
        }
    }
}
