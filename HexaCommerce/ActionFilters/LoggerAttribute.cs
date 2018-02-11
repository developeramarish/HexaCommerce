using Hexa.Business.Models.Logs;
using Hexa.Core;
using Hexa.Service.Contracts.Logs;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using System;
using System.Linq;

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
            StringValues authorizationToken;

            if (context.Exception != null)
            {
                var encodedString = context.HttpContext.Request.Headers.TryGetValue("Token", out authorizationToken);

                if (!string.IsNullOrEmpty(authorizationToken.First()))
                {
                    var key = EncryptionLibrary.DecryptText(authorizationToken.First());

                    string[] parts = key.Split(new char[] { ':' });

                    var customerId = Convert.ToInt32(parts[0]);

                    var exception = context.Exception;
                    var model = new LogModel
                    {
                        ShortMessage = exception.Message,
                        FullMessage = exception?.ToString() ?? string.Empty,
                        CustomerId = customerId,
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
}
