using Microsoft.AspNetCore.Mvc;

namespace HexaCommerce.Api.Web
{
    public class HomeController : BasePublicApiController
    {
        public IActionResult Get(int id)
        {
            return Ok("Welcome to home page");
        }
    }
}