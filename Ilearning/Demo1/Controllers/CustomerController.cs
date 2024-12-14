using Demo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    public class CustomerController : Controller
    {

        public IActionResult Index(int id)
        {
            var v = new Customer_oders();
            var customer =  v.GetCustomer(id);
            return PartialView("CUSTOMER", customer);   // customer is a partialView
        }
        public IActionResult GETALL()
        {
            var v = new Customer_oders();
            var all = v.GetAllCustomer();
            return View("ALLCUSTOMER",all);
        }


    }
}
