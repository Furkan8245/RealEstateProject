using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CCS
{
    public interface ILogger
    {
        void Log(int userId, string status, string operationType, string desc, string ip);
    }
}
