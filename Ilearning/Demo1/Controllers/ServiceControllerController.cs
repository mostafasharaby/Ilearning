using Microsoft.AspNetCore.Mvc;
using Demo1.Repository;
using Demo1.Filters;
using System.Web.Http;
using System.Security.Claims;
namespace Demo1.Controllers
{
    //[MyFilter]
    
    public class ServiceControllerController : Controller
	{
        [Authorize]
        public IActionResult TestClaims()
		{
			var name = User.Identity.Name;
			var Role = User.Identity.AuthenticationType; 
			var id = User.Claims.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier); //like context.Emp..... 
            //var userClaims = User.Claims;
            //var emailClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            //if (emailClaim != null && emailClaim.Value.EndsWith("@example.com"))
            //{
            //    // Allow access
            //    return Content("Allow access");
            //}

            return Content($"id : {id.Value} {name}    {Role} ");
		}
         

       IDepartmentRepository dptRep ;
        public ServiceControllerController(IDepartmentRepository dptRep)
        {
            this.dptRep = dptRep;
        }
        public IActionResult Index()
		{
			ViewBag.ID = dptRep.Guid;
			ViewData["Greet"] = "Hello From the other side";
			return View();
		}

		
		public IActionResult TestFilter()
		{
			return Content("Hi");
		}
	}
}
