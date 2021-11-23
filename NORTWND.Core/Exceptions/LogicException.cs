using System;
using System.Net;

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
