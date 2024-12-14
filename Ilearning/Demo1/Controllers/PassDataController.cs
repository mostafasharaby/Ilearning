using Demo1.Models;
using Demo1.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    public class PassDataController : Controller
    {
        MVCDbContext context = new MVCDbContext();
        public IActionResult testViewData(int id )
        {
            var v = context.Employees.FirstOrDefault(i=>i.ID== id);
            //Extra info 
            string msg = "Hellow World";
            List<string> result = new List<string> {"Alex" , "Cairo","Baltim" };
            string color = "red";
          //  ViewData["Message"] = msg;
            ViewData["Result"] = result;
            ViewData["COLOR"] = color;
            ViewBag.Message = "new message";
         
            return View(v);
        }
        /*
         A cookie is a small piece of data that a server sends to the client (usually a web browser),
        which is then stored on the client’s machine. Cookies are primarily used to store information about the user or their interaction with the website,
        such as user ID, user name, login status, token, etc, and are sent back to the website with every subsequent request. 
        */
        public IActionResult testViewModel(int id )
        {
            var v = context.Employees.FirstOrDefault(i=>i.ID== id);
            List<string> result = new List<string> {"Alex" , "Cairo","Baltim" };
            string color = "red";          
            ViewData["Result"] = result;
            ViewData["COLOR"] = color;
            FirstViewModel vm = new FirstViewModel();
            vm.Temp = 20;
            vm.EmpName = "mostafa";
            vm.Values = result;
            vm.EmpId = id;
            vm.Color = color;
           

            return View( vm);
        }
    



        }
}
