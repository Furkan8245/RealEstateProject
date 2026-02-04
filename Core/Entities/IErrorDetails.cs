using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public interface IErrorDetails
    {
        string ErrorMessage { get; set; }
        int StatusCode { get; set; }
    }
}
