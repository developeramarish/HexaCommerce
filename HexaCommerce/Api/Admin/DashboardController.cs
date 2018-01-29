using Microsoft.AspNetCore.Mvc;

namespace HexaCommerce.Api.Admin
{
    public class DashboardController : BaseAdminApiController
    {
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok("visit by auth token");
        }
    }
}