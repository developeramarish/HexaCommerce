using HexaCommerce.ActionFilters;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace HexaCommerce.Api.Web
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [TypeFilter(typeof(LoggerAttribute))]
    public class BasePublicApiController : Controller
    {
        
    }
}
