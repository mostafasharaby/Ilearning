using Demo1.Models;
using Demo1.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    public class TranieeController : Controller
    {
        ITraineeRepository traineeRepository;
     //   StudentDbContext context = new StudentDbContext();
        public TranieeController(ITraineeRepository traineeRepository)
        {
            this.traineeRepository = traineeRepository;
        }

        public IActionResult Index()
        {
            var e = traineeRepository.GetAll();
            return View("Index", e);
        }
         
        [HttpGet]
        public IActionResult New()
        {
            ViewData["list"] = traineeRepository.GetAllDepartment();
            return View(new Traniee());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult savenew( Traniee e, IFormFile ImageFile)
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
                    traineeRepository.insert(e);
                    var ee = traineeRepository.GetAll(); //old refrence
                    return RedirectToAction("IndexAjax");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }
            ViewData["list"] = traineeRepository.GetAllDepartment();
            return View("New", e);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ty = traineeRepository.GetByid(id); 
            if (ty == null)
            {
                return NotFound();
            }
            ViewData["list"] = traineeRepository.GetAllDepartment();
            return View(ty);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult saveEdite(int id, Traniee e, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                var em = traineeRepository.GetByid(id);
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

                    traineeRepository.update(id, e);
                    var ee = traineeRepository.GetAll();
                    return RedirectToAction("IndexAjax");
                }
            }

            ViewData["list"] = traineeRepository.GetAllDepartment();
            return View("Edit", e);
        }

        public IActionResult Delete(int id)
        {
            var deleteEmp = traineeRepository.GetByid(id);
            if (deleteEmp != null)
            {
             traineeRepository.Delete(id);
            }
            return RedirectToAction("IndexAjax");
        }
      

        public IActionResult IndexAjax()
        {
            var e = traineeRepository.GetAll();
            return View(e);
        }
        public IActionResult DetailsAjax(int id)
        {
            var x = traineeRepository.GetByid(id);
            return PartialView("_TranieeDetails", x);
        }
    }
}
