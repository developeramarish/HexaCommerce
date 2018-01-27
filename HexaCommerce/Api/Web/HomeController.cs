using Microsoft.AspNetCore.Mvc;
using WebAngularRAC.Filters;

namespace HexaCommerce.Api.Web
{
    [Produces("application/json")]
    [Route("api/home")]
    [TypeFilter(typeof(UserAuthorizeAttribute))]
    public class HomeController : Controller
    {
        // GET api/values/5  
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "visit by jwt auth";
        }

        // GET api/values/5  
        //[HttpGet]
        //public string Values(int id)
        //{
        //    return $"visiting without authentication {id}";
        //}
    }
}