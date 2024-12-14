using Demo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    public class StateManagementController : Controller
    {
        MVCDbContext context = new MVCDbContext();

        public IActionResult SetCookie()
        {
            CookieOptions cookieOptions = new CookieOptions();    // persestance cookie
            cookieOptions.Expires = DateTimeOffset.Now.AddDays(1);
            Response.Cookies.Append("name", "Mostafa", cookieOptions);
            Response.Cookies.Append("age", "21");
            return Content("Cookie saved"); 
        }
        public IActionResult GetCookie()
        {
            string name = Request.Cookies["name"];
            string age=  Request.Cookies["age"];
            return Content($"Data is {name}  age : {age}");
        }


        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("Name", "Mohamed");
            HttpContext.Session.SetInt32("ID", 1);
            return Content("session1  saved sucssessfully");
        }
        public IActionResult GetSession()
        {
            string? name =  HttpContext.Session.GetString("Name");
            int? id =  HttpContext.Session.GetInt32("ID");
            return Content($"session1 date name = {name} , id {id} ");
        }


        public IActionResult set()
        {
            TempData["Message"] = "this is Temp Data\n";
            return Content("set 1");
        }
        public IActionResult GET1()
        {
            string msg = "Empty"; 
            if (TempData.ContainsKey("Message"))
            {
                // msg = (string)TempData["Message"];
                msg = TempData.Peek("Message").ToString();  // to keep data From Deletion
               TempData.Keep("Message");
            }
            
            return Content("GET1 1" + msg);
        }
        public IActionResult GET2()
        {
            string msg = (string)TempData["Message"];
            return Content("GET2 2" + msg);
        }
    }
}
