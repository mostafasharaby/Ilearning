using Demo1.Models;
using Demo1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Controllers
{
    public class StudentController : Controller
    {
        StudentDbContext context = new StudentDbContext();
        public IActionResult AllTraniee(int id)
        {
            var v = context.Traniees.ToList();
            return View(v);
        }
        public IActionResult Detail(int id)
        {
            var v = context.Traniees.FirstOrDefault(i=>i.Id== id);
            if (v == null)
            {
                return NotFound(); 
            }

            return View(v);
        }
        public IActionResult StudViewModel(int id)
        {

            string msg = "this is my new project";
            ViewBag.msg = "this is my OLD project";
            ViewData["Message"] = msg; 
            var trainee = context.Traniees
                         .Include(t => t.CrsResult)
                         .FirstOrDefault(i => i.Id == id);

            if (trainee == null)
            {
                return NotFound();
            }

            var vm = new StudentViewModel
            {
                Id = trainee.Id,
                TranieeName = trainee.Name,
                TranieeDegree = trainee.Degree ?? 0,
                Color = trainee.Degree > 50 ? "Green" : "Red",
                Image = trainee.Image,
                CrsResult = trainee.CrsResult
            };

            return View(vm);
        }
        


    }
}
