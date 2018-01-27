using Hexa.Business.Models.Customers;
using Hexa.Service.Authentication;
using Hexa.Service.Contracts.Customers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HexaCommerce.Api.Web
{
    [Produces("application/json")]
    public class LoginController : BaseApiPublicController
    {
        private readonly ICustomerService _customerService;

        public LoginController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]CustomerLoginModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Username.Trim()) || string.IsNullOrEmpty(model.Password))
                {
                    return Unauthorized();
                }

                var customer = _customerService.ValidateCustomer(model.Username.Trim(), model.Password);

                if (customer == null)
                {
                    return Unauthorized();
                }

                var result = _customerService.GetLoginResponse(customer);

                if (result == null)
                {
                    return Unauthorized();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }

        }
    }
}