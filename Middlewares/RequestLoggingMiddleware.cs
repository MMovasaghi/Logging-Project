using System;
using System.Threading.Tasks;
using logMiddlewareProject.Repository.IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace logMiddlewareProject.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
        }
        public async Task Invoke(HttpContext context, ILogRepo log)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                _logger.LogInformation(
                    "Request {method} {url} => {statusCode}",
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    context.Response?.StatusCode);

                Models.log newLog = new Models.log()
                {
                    Method = context.Request?.Method,
                    Url = context.Request?.Path.Value,
                    StatusCode = context.Response?.StatusCode,
                    username = "ALI"
                };
                await log.Create(newLog);
            }
        }
    }
}