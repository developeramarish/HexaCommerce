using HexaCommerce.ActionFilters;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace HexaCommerce.Api.Admin
{
    [Route("admin/api/[controller]")]
    [Produces("application/json")]
    [TypeFilter(typeof(AdminAuthorizeAttribute))]
    [TypeFilter(typeof(LoggerAttribute))]
    public class BaseAdminApiController : Controller
    {

    }
}
