using Demo1.Filters;
using Demo1.Models;
using Demo1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Filters;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
namespace Demo1.Controllers
{
    public class DepartmentController : Controller  
    {
        /// <summary>
        /// When a service requires an IDepartmentRepository (like your DepartmentController),
        /// the DI container will inject an instance of DepartmentRepository.
        /// </summary>
        /// services.AddScoped<IDepartmentRepository, DepartmentRepository>():
        ///This registers the IDepartmentRepository interface and its 
        ///implementation DepartmentRepository with the DI container with a scoped lifetime.



        //  MVCDbContext context = new MVCDbContext();
        //IDepartmentRepository dptRep;// = new DepartmentRepository();
        IDepartmentRepository dptRep;// = new DepartmentRepository();        
        public DepartmentController(IDepartmentRepository dptRep)  //. This instance is injected by the dependency injection (DI) 
        {
            this.dptRep = dptRep;   // ask
        }
        public IActionResult Index()
        {
            List<Department> list = dptRep.GetAll();
           // return View("Index", list);
            return View( list);
            //return View("Index");
        }
        //[Authorize]
       // [MyFilter]
        public IActionResult Details(int id)
        {
            var department = dptRep.GetById(id);    
            return PartialView("_DepartmentDetails", department);
        }
        [Authorize] 
        public IActionResult indexAjax()
        {
            List<Department> list = dptRep.GetAll();
            return View(list);
        }


        [HttpGet] //anchor tag && form method get
        public IActionResult New()
        {
          //  ViewData["EmpList"] = context.Employees.ToList();
            return View(new Department()); 
        } 
        [HttpPost] //form method 
        public IActionResult savenew(Department dp)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    dptRep.Insert(dp);
                  //  List<Department> list = context.Departments.Include(i => i.Employees).ToList();
                    return RedirectToAction("index");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }               
            }
        //    ViewData["EmpList"] = context.Employees.ToList();
            return View("New", dp);
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

    }
    
}
