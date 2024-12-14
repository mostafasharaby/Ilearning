using Demo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    public class ProductController : Controller
    {
       //public string Name()
       // {
       //     return "hellow world";
       // }
       // public string Index(int i ) {
       //     if (i % 2 == 0) return "even";
       //     else return "odd";
       // }
       // public ContentResult ContentResult()
       // {
       //     return new ContentResult { Content = "wer" };
       // }
       // public ViewResult ViewResult()
       // {
       //     //return new ViewResult { ContentType = "text/html", ViewName = "V1" };
       //     return View("V1");
       // }
       // public JsonResult JsonResult() 
       // {
       //     return new  JsonResult(new {id = 4 , name = "nmo" , age  = 10});
       // }
       // public IActionResult actionResult(int id, int age )
       // {
       //     if(id % 2 == 0)
       //     {
       //         return Content("HELLO WORLD"); 
       //     }
       //     else
       //     {
       //         //return new JsonResult(new { id = 4, name = "@34", age = 70 }); 
       //         return Json(new { id = 4, name = "@34", age = 70 }); 
       //     }
       // }
       public IActionResult GetResult(int id)
        {
            var v = new ProductSampleData();
            Product p =  v.GetbyId(id);
            return View("Product_details",p);
        }
        public IActionResult ShowAll()
        {
            var v = new ProductSampleData();
            var p = v.Getall();
            return View("ALL",p);
        }
        public string Name()
        {
            return "hellow world";
        }
    }
}
