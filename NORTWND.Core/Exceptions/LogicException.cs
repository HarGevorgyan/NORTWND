using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NORTWND.Core.Exceptions
{
    public class LogicException:Exception
    {
        public HttpStatusCode StatusCode {  get; set; }

        public LogicException(string message,HttpStatusCode statusCode):base(message)
        {
            StatusCode = statusCode;
        }
        public LogicException(string message) : this(message, HttpStatusCode.BadRequest) { }
        
    }
}
