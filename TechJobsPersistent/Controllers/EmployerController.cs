using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechJobsPersistent.Data;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        //1. set up private DbContext variable
        private JobDbContext context;
        public EmployerController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        //2. passes all of the Employer objects in the database to the view.
        [HttpGet] //route /Employer
        public IActionResult Index()
        {
            List<Employer> employers = context.Employers.ToList();
            return View(employers);
        }

        //3. Create instance of AddEmployerViewModel n pass instance into View() return method.
        [HttpGet]
        public IActionResult Add()
        {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();
            return View(addEmployerViewModel);
        }

        //4. process form submissions so that only valid Employer objects are added to database
        [HttpPost]
        [Route("/Employer/Add")]
        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {
            if (ModelState.IsValid)
            {
                Employer newEmployer = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location
                };
                context.Employers.Add(newEmployer); //add new employer to class
                context.SaveChanges(); //save new employer to database
                return Redirect("/Employer");
            }
            return View("Add", addEmployerViewModel);
        }

        //5. display info for selected employer of specific id
        [HttpGet]
        public IActionResult About(int id)
        {
            ViewBag.selectedEmployer = context.Employers.Find(id);
            ViewBag.name = ViewBag.selectedEmployer.Name;
            ViewBag.location = ViewBag.selectedEmployer.Location;
            return View();
        }
    }
}
