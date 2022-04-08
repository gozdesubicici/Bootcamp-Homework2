using AuthorizationAndResourceFilters.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationAndResourceFilters.Controllers
{
    [CacheResource]
    public class CachedController : Controller
    {
        public IActionResult Index()
        {
            return Content("Bu içerik şu zamanda oluşturuldu: " + DateTime.Now);
        }
    }
}
