using Demo1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using static System.Net.Mime.MediaTypeNames;

namespace Demo1.Controllers
{
	public class EmployeeController : Controller
	{
		MVCDbContext context = new MVCDbContext();
		public IActionResult Index()
		{
			var e = context.Employees.ToList();
			return View("Index", e);
		}
		[HttpGet]
		public IActionResult New()
		{
            ViewData["DepartmentList"] = context.Departments.ToList();
            return View(new Employee());			
		}
		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult savenew(Employee e , IFormFile ImageFile)
		{
			if (ModelState.IsValid)
			{
                try
                {
                    if (ImageFile != null)
                    {
                        // Save the image to wwwroot/images
                        string fileName = Path.GetFileName(ImageFile.FileName);
                        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            ImageFile.CopyTo(stream);
                        }
                        e.Image = fileName; // Store the file name in the Image property
                    }
                    context.Employees.Add(e);
                    context.SaveChanges();
                    var ee = context.Employees.ToList(); //old refrence
                    return RedirectToAction("IndexAjax");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
								
			}			
				ViewData["DepartmentList"] = context.Departments.ToList();
				return View("New", e);			
		}


        public IActionResult IndexEdit()
        {
            var e = context.Employees.ToList();
            return View(e);
        }
        public IActionResult Edit(int id )
        
        {
           var ty = context.Employees.FirstOrDefault(i => i.ID == id);
            if (ty == null)
            {
                return NotFound();
            }
            ViewData["list"] = context.Departments.ToList();			
            return View(ty);
        }
       // [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult saveEdite( int id , Employee e , IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                var em = context.Employees.FirstOrDefault(i => i.ID == id);
                if (em != null)
                {
                    if (ImageFile != null)
                    {
                        // Save the new image to wwwroot/images
                        string fileName = Path.GetFileName(ImageFile.FileName);
                        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            ImageFile.CopyTo(stream);
                        }
                        em.Image = fileName; // Update the image property
                    }


                    em.Name = e.Name;
                    em.Salary = e.Salary;
                    em.Address = e.Address;
                    em.DepartmentID = e.DepartmentID;
                  //  em.Image = e.Image;
                    context.SaveChanges();
                    return RedirectToAction("IndexAjax");
                    //return RedirectToAction("Detail", "Student", new { id = 2 });
                }
            }

            ViewData["list"] = context.Departments.ToList();
            return View("Edit", e);            
        }

        public IActionResult Delete(int id)
		{
            var deleteEmp = context.Employees.FirstOrDefault(e => e.ID == id);
            if (deleteEmp != null)
            {
                context.Employees.Remove(deleteEmp);
                context.SaveChanges(); 
            }
			return RedirectToAction("IndexAjax");
        }
        public IActionResult CheckSalary(int Salary)
        {
           if(Salary < 10)
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
            
        }
    
        public IActionResult IndexAjax()
        {
            var e = context.Employees.ToList();
            return View(e);
        }
        public IActionResult DetailsAjax(int id)
        {
            var department = context.Employees.FirstOrDefault(i => i.ID == id);
            return PartialView("_EmployeeDetails", department);
        }


    }
}
//            <td><img width="30px" height="100px" class="card-img-top" src="/images/@i.Image" alt="Card image"> </td>
