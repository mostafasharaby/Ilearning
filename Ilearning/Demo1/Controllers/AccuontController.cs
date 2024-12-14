using Demo1.Models;
using Demo1.ViewModel;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Data;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Demo1.Controllers
{
    public class AccuontController : Controller
    {

        /// <summary>
        /// Data entered by the user in the registration form (view) is captured by the RegisterUserViewModel.
        ///This data is then transferred to an instance of AppUser to create a new user in the system.
        /// This mapping process allows you to control and validate the input data before it is used to create the domain model.
        /// /* https://chatgpt.com/share/235d6393-f3a0-4000-a8cf-8cbc3f080796 */
        /// </summary>
        private readonly UserManager<AppUser> userManager;//creating users, finding users, etc.
        private readonly SignInManager<AppUser> signInManager; // Manages sign-in operations like creating cookies, signing users in, 
        public AccuontController(UserManager<AppUser> userManager ,SignInManager<AppUser> signInManager)
        {  //uses dependency injection to get instances of UserManager  and signInManager
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Regeister()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Regeister(RegisterUserViewModel registerUser)
        {
            // mapping from ViewModel to AppUser
            AppUser appUser = new AppUser();
            appUser.UserName = registerUser.UserName;
            appUser.Address = registerUser.Address;
            appUser.PasswordHash = registerUser.PasswordConfirmed;
            appUser.PasswordHash = registerUser.Password;


            if (ModelState.IsValid)// -->store > context > database
            {
                // save database
                IdentityResult result = await userManager.CreateAsync(appUser, registerUser.Password); // validation (registerUser.Password)
                await userManager.AddClaimAsync(appUser, new Claim(ClaimTypes.Name, appUser.UserName)); // add to DB
                if (result.Succeeded)  
                {
                    //add role 
                    List<string> ls = new List<string>();
                    ls.Add("Admin");
                    await userManager.AddToRoleAsync(appUser, "Admin"); 
                    // Create Cookies
                     await signInManager.SignInAsync(appUser,false); //Signs in the user if creation is successful.(// Create Cookies ) (false -> presistance/session cookie)                    
                    return RedirectToAction("indexAjax", "Employee");  
                }
                else
                {
                    foreach (var v in result.Errors)
                    {
                        ModelState.AddModelError("Passward", v.Description);  ////Adds validation errors to the model state if creation fails.
                    }
                }
            }
            return View(registerUser);
        }
        public IActionResult LogOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Regeister");
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogInViewModel logInView)
        {
            if(ModelState.IsValid)
            {
             AppUser appUser =  await userManager.FindByNameAsync(logInView.UserName);
                if (appUser != null)
                {

                    
                    bool found =  await userManager.CheckPasswordAsync(appUser, logInView.Password);                   
                    if (found == true )
                    {

                        ///Authentication: Claims can be added during the authentication process, 
                        ///such as when a user logs in. The claims could include information like the user's email, role, and permissions.
                        ///Summary:
                        ///A claim in MVC represents a piece of information about the user, like their email or role.

                        #region AddClaims
                        // Add claims here
                        //var claims = new List<Claim>
                        //{
                        //    new Claim(ClaimTypes.Name, appUser.UserName),
                        //    new Claim(ClaimTypes.Role, "Admin"), // Example role
                        //    new Claim("Permission", "CanEdit") , // Example permission
                        //    new Claim(ClaimTypes.NameIdentifier, appUser.UserName),

                        //};
                        //var claimsIdentity = new ClaimsIdentity(claims, "login");
                        #endregion
                       

                        var result = await signInManager.PasswordSignInAsync(appUser, logInView.Password, logInView.RememberMe, lockoutOnFailure: false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("indexAjax", "Employee");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Invalid login attempt.");
                        }

                        // create cookie
                        // await signInManager.SignInAsync(appUser, logInView.RememberMe);
                    }
                    else
                    {
                        ModelState.AddModelError("", "UserName or Password is wrong");
                    }                    
                }
                else
                {
                    ModelState.AddModelError("", "UserName or Password is wrong");
                }

            }
            
            return View(logInView);
        }
        public IActionResult Index()
        {
            // Access claims
            var n = User.Identity.Name;
            var name = User.Claims.FirstOrDefault(i => i.Type == ClaimTypes.Name)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            var nameIdentitfier = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var permission = User.FindFirst("Permission")?.Value;
          //  var address = User.Claims.FirstOrDefault(i=>i.Type ==ClaimTypes.Country)?.Value;
            // Use the claims (e.g., pass them to the view)
            ViewBag.nameIdentitfier = nameIdentitfier;
            ViewBag.Name = name;
            ViewBag.Role = role;
            ViewBag.Permission = permission;
            ViewBag.Name = n;
            // ViewBag.Address = address;

            return View();
        }
        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAdmin(RegisterUserViewModel registerUser)
        {
            // mapping from ViewModel to AppUser
            AppUser appUser = new AppUser();
            appUser.UserName = registerUser.UserName;
            appUser.Address = registerUser.Address;
            appUser.PasswordHash = registerUser.PasswordConfirmed;
            appUser.PasswordHash = registerUser.Password;

            if (ModelState.IsValid)// -->store > context > database
            {
                // save database
                IdentityResult result = await userManager.CreateAsync(appUser, registerUser.Password);//, registerUser.Password); // validation (registerUser.Password)
                await userManager.AddClaimAsync(appUser, new Claim(ClaimTypes.Name, appUser.UserName)); // add to DB
                if (result.Succeeded)
                {
                    //add role 
                    //List<string> ls = new List<string>();
                    //ls.Add("Admin");
                    await userManager.AddToRoleAsync(appUser, "Admin");
                    // Create Cookies
                    await signInManager.SignInAsync(appUser, false); //Signs in the user if creation is successful.(// Create Cookies ) (false -> presistance/session cookie)                    
                    return RedirectToAction("indexAjax", "Employee");
                }
                else
                {
                    foreach (var v in result.Errors)
                    {
                        ModelState.AddModelError("Passward", v.Description);  ////Adds validation errors to the model state if creation fails.
                    }
                }
            }
            return View(registerUser);
        }

        

    }
}
