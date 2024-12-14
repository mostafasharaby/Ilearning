using Demo1.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using System.Web.Http;

namespace Demo1.Controllers
{



    [System.Web.Http.Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        [System.Web.Http.HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New2(RoleViewModel roleViewModel)
        {
            var AppRole = new IdentityRole();
            AppRole.Name = roleViewModel.RoleName;

            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(AppRole);
                if(result.Succeeded)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    foreach(var v in result.Errors)
                    {
                        ModelState.AddModelError("", v.Description);
                    }
                }
            }
            return View(roleViewModel);
        }
    }
}
