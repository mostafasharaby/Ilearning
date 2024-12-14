using Demo1.Models;
using Demo1.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Demo1.Controllers
{
    public class CourseController : Controller
    {
        //StudentDbContext context = new StudentDbContext();
        ICourseRepository crsrepo;// = new CourseRepository();
        public CourseController(ICourseRepository crsrepo) 
        {
            this.crsrepo = crsrepo;
        }
        public IActionResult Index()
        {
            var crs = crsrepo.GetAll();
            return View(crs);
        }

        public IActionResult NewCrs()
        {
            ViewData["list"] = crsrepo.GetAllDepartment();
            return View(new Course());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Course cs)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    crsrepo.insert(cs);
                    return RedirectToAction("Index");
                }
                catch(Exception e)
                {
                     ModelState.AddModelError(string.Empty, e.Message);// if the key the same name of property model---> "span" else in "div"
                    //ModelState.AddModelError("Name", e.Message);
                }                
            }            
              return View("NewCrs", cs);            
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = crsrepo.GetByid(id);
            if (course == null)
            {
                return NotFound();
            }

            ViewData["list"] = crsrepo.GetAllDepartment();
            return View("NewCrs", course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course cs , int id)
        {
            if (ModelState.IsValid)
            {
                    crsrepo.update(id, cs);                   
                    return RedirectToAction("Index");                
            }

            ViewData["list"] = crsrepo.GetAllDepartment();
            return View("NewCrs", cs);
        }
       
        public IActionResult Delete(int id)
        {
            var course = crsrepo.GetByid(id);
            crsrepo.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult CheckMindegree (int Mindegree , int Degree)
        {
            if(Mindegree >= Degree)
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }

    }
}
