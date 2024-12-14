using Demo1.Models;
using Demo1.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    public class StudentAccountController : Controller
    {
        private readonly UserManager<StudentUser> userManager;
        private readonly SignInManager<StudentUser> signInManager;

        public StudentAccountController(UserManager<StudentUser> userManager  ,SignInManager<StudentUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.signInManager= signInManager;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterStudentUserModelView registerStudent)
        {       
            StudentUser studentUser = new StudentUser();
            studentUser.UserName = registerStudent.Name;
            studentUser.Email = registerStudent.Email;
            studentUser.Address = registerStudent.Address;
            studentUser.Faculty = registerStudent.Faculty;

            if (ModelState.IsValid)
            {
              IdentityResult result =  await userManager.CreateAsync(studentUser, registerStudent.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(studentUser, false);
                    return RedirectToAction("indexAjax", "Employee");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("",error.Description);
                    }
                }
              
            }
            return View(registerStudent);  //  was the error : 64 string .....
        }

        public IActionResult LogOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Register");
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(StudentLogin studentLogin) 
        {
            if (ModelState.IsValid) { 
                StudentUser user = await userManager.FindByNameAsync(studentLogin.Name);
                if(user != null)
                {
                    bool found = await userManager.CheckPasswordAsync(user, studentLogin.Password);
                    if(found == true)
                    {
                        var  result = await signInManager.PasswordSignInAsync(user, studentLogin.Password, studentLogin.RememberMe,lockoutOnFailure:false);
                        if (result.Succeeded)
                        {
                            //// return RedirectToAction("Index", "Course");
                            if (await userManager.IsInRoleAsync(user, "Admin"))
                            {
                                return RedirectToAction("AdminDashboard");
                            }
                           // If the user is a Student
                            else if (await userManager.IsInRoleAsync(user, "Student"))
                            {
                                return RedirectToAction("Index", "Course");
                            }
                            else if (await userManager.IsInRoleAsync(user, "Instructor"))
                            {
                                return RedirectToAction("Index", "Instractors");
                            }
                            else
                            {
                                // Handle case where the user has no role or an unexpected role
                                ModelState.AddModelError("", "Unexpected role. Please contact support.");
                            }

                        }
                        else
                        {
                                ModelState.AddModelError("", "Invalid login attempt.");
                        }
                        await signInManager.SignInAsync(user, studentLogin.RememberMe);
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
            return View(studentLogin);

        }
     
        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAdmin(RegisterStudentUserModelView registerStudent)
        {
            StudentUser studentUser = new StudentUser();
            studentUser.UserName = registerStudent.Name;
            studentUser.Email = registerStudent.Email;
            studentUser.Address = registerStudent.Address;

            studentUser.Faculty = registerStudent.Faculty;

            if (ModelState.IsValid)
            {
                IdentityResult result = await userManager.CreateAsync(studentUser, registerStudent.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(studentUser, "Admin"); // changed
                    await signInManager.SignInAsync(studentUser, false);
                    return RedirectToAction("AdminDashboard");
                }
                else 
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return View(registerStudent);  //  was the error : 64 string .....
        }
        [HttpGet]
        public IActionResult AddInstructor()
        {
            return View();
        }
        public IActionResult AdminDashboard()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddInstructor(RegisterStudentUserModelView registerStudent)
        {
            StudentUser studentUser = new StudentUser();
            studentUser.UserName = registerStudent.Name;
            studentUser.Email = registerStudent.Email;
            studentUser.Address = registerStudent.Address;


            if (ModelState.IsValid)
            {
                IdentityResult result = await userManager.CreateAsync(studentUser, registerStudent.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(studentUser, "Instructor"); // changed
                    await signInManager.SignInAsync(studentUser, false);
                    return RedirectToAction("index", "Instractors");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return View(registerStudent);  //  was the error : 64 string .....
        }    
    }
}
