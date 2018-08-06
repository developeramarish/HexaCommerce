using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HexaCommerce.Api.Admin
{
    public class DashboardController : BaseAdminApiController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Task.FromResult("visit by auth token"));
        }
    }
}