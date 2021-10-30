using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NORTWND.Core.Exceptions;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace NORTWND.API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next,ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(LogicException logicException)
            {
                _logger.LogError(logicException, logicException.Message);
                var message = logicException?.InnerException?.Message ?? logicException.Message;
                await WriteExceptionResponseAsync(context, message, logicException.StatusCode);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var message = ex.InnerException?.Message ?? ex.Message;

                await WriteExceptionResponseAsync(context, message, HttpStatusCode.InternalServerError);
            }
        }
        private  Task WriteExceptionResponseAsync(HttpContext context,string data,HttpStatusCode statusCode)
        {
            var response = context.Response;
            response.StatusCode = (int)statusCode;

            return response.WriteAsync(JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }));
        }
    }
}
