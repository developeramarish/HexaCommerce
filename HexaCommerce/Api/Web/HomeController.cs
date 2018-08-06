using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HexaCommerce.Api.Web
{
    public class HomeController : BasePublicApiController
    {
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Task.FromResult("Welcome to home page"));
        }
    }
}