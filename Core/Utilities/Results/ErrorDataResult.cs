using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, true, message)
        {
        }

        public ErrorDataResult(T data) : base(data, true)
        {
        }
        public ErrorDataResult(string messsage) : base(default, true, messsage)
        {

        }
        public ErrorDataResult() : base(default, true)
        {

        }

    }
}
