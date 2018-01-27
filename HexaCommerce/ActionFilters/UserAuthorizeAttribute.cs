using Hexa.Core;
using Hexa.Core.Domain.Customers;
using Hexa.Service.Contracts.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;
using System.Net;

namespace WebAngularRAC.Filters
{
    public class UserAuthorizeAttribute : ActionFilterAttribute
    {
        private readonly ICustomerService _customerService;
        public UserAuthorizeAttribute(ICustomerService customerService)
        {
            _customerService = customerService; ;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            StringValues authorizationToken;

            try
            {
                var encodedString = context.HttpContext.Request.Headers.TryGetValue("Token", out authorizationToken);

                if (!string.IsNullOrEmpty(authorizationToken.First()))
                {
                    var key = EncryptionLibrary.DecryptText(authorizationToken.First());

                    string[] parts = key.Split(new char[] { ':' });

                    var customerId = Convert.ToInt32(parts[0]);       // customerId
                    var RandomKey = parts[1];                     // Random Key
                    var customerRoleIds = parts[2].Split(',').Select(int.Parse).ToList();   // UserTypeID
                    long ticks = long.Parse(parts[3]);            // Ticks
                    DateTime IssuedOn = new DateTime(ticks);

                    var customer = _customerService.ValidateCustomerRole(customerId, (int)CustomerRoleEnum.Registered);

                    if (customer == null)
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        context.Result = new UnauthorizedResult();
                    }

                    return;
                }
                else
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    context.Result = new UnauthorizedResult();
                }

            }
            catch (Exception)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new UnauthorizedResult();
            }

            base.OnActionExecuting(context);
        }
    }
}
