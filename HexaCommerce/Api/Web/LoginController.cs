using Hexa.Business.Models.Customers;
using Hexa.Service.Contracts.Customers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HexaCommerce.Api.Web
{
    public class LoginController : BasePublicApiController
    {
        private readonly ICustomerService _customerService;

        public LoginController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CustomerLoginModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Username.Trim()) || string.IsNullOrEmpty(model.Password))
                {
                    return Unauthorized();
                }

                var customer = await _customerService.ValidateCustomer(model.Username.Trim(), model.Password);

                if (customer == null)
                {
                    return Unauthorized();
                }

                var result = await _customerService.GetLoginResponse(customer);

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