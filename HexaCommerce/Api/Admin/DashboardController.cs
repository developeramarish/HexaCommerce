using Microsoft.AspNetCore.Mvc;

namespace HexaCommerce.Api.Admin
{
    public class DashboardController : BaseAdminApiController
    {
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "visit by jwt auth";
        }
    }
}