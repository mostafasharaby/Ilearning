using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    public class RouteController : Controller
    {
        [Route("show/{id}")]
        public IActionResult Index(int id)        
        {
            return Content("this is 1");
        }
    }
}
