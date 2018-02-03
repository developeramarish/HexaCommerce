using Hexa.Business.Models.Logs;
using Hexa.Service.Contracts.Logs;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using System;

namespace HexaCommerce.ActionFilters
{
    public class LoggerAttribute : ExceptionFilterAttribute
    {
        private readonly ILogService _logService;

        public LoggerAttribute(ILogService logService)
        {
            _logService = logService;
        }

        public override void OnException(ExceptionContext context)
        {
            if (context.Exception != null)
            {
                var exception = context.Exception;
                var model = new LogModel
                {
                    ShortMessage = exception.Message,
                    FullMessage = exception?.ToString() ?? string.Empty,
                    CustomerId = 151,
                    IpAddress = context.HttpContext.Connection.RemoteIpAddress?.ToString(),
                    PageUrl = $"{context.HttpContext.Request.PathBase}{context.HttpContext.Request.Path}{context.HttpContext.Request.QueryString}",
                    CreatedOn = DateTime.UtcNow,
                    PageReferrer = $"{context.HttpContext.Request.Headers[HeaderNames.Referer]}",
                };
                _logService.InsertLog(model);
            }
        }
    }
}
