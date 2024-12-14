using Demo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    public class BindingController : Controller
    {
        public IActionResult TestPremitive(int id , string name ,int age ,string[] arr)
        {
            return Content($"{id} , {name}"); 
        }
        public IActionResult TestDic(Dictionary<string, int> phones, string name) //localhost:23941/Binding/TestPremitive?name=Shady&phones[ali]=12&phones[shady]=23 
        {
            return Content($"{name}");
        }

        //public IActionResult TestComplex(string name, string Manager, Departement dep) //localhost:23941/Binding/TestComplex/1?name=Shady&Manager=Samir
        //{
        //    //http://localhost:23941/Binding/TestComplex/1?name=Shady&Manager=Samir&traniees[0].Id=1&traniees[0].Name=Ali&traniees[1].Id=2&traniees[1].Name=Ahmed
        //    return Content($"{name}  {Manager}");
        //}
        //public IActionResult TestComplex( Departement dep) //localhost:23941/Binding/TestComplex/1?name=Shady&Manager=Samir
        //{
        //    //http://localhost:23941/Binding/TestComplex/1?name=Shady&Manager=Samir&traniees[0].Id=1&traniees[0].Name=Ali&traniees[1].Id=2&traniees[1].Name=Ahmed
        //    return Content($"{name}  {Manager}");
        //}
        public IActionResult TestComplex([Bind(include: "Id,Name")] Departement dep) //localhost:23941/Binding/TestComplex/1?name=Shady&Manager=Samir
        {
            //http://localhost:23941/Binding/TestComplex/1?name=Shady&Manager=Samir&traniees[0].Id=1&traniees[0].Name=Ali&traniees[1].Id=2&traniees[1].Name=Ahmed
            return Content("All Alright");
        }
    }
}
//http://localhost:23941/Binding/TestDic?name=Shady&phones[ali]=12&phones[shady]=23
//http://localhost:23941/Binding/TestDic?name=Shady&phones[ali]=12&phones[shady]=23