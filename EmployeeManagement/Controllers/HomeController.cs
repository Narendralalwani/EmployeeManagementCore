using EmployeeManagement.Model;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{

    
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ILogger _ilogger;

        public HomeController(IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment, ILogger<HomeController> ilogger)
        {
            _employeeRepository = employeeRepository;
            this.hostingEnvironment = hostingEnvironment;
            this._ilogger = ilogger;
        }
       
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployees();
            //return _employeeRepository.GetEmployee(1).Name;
            return View(model);
        }
        public ViewResult Details(int? id)
        {
            // throw new Exception("Error in detail page");

            //_ilogger.LogInformation("Information Log Test");
            Employee employee = _employeeRepository.GetEmployee(id.Value);

            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id);
            }
            // Employee emp = _employeeRepository.GetEmployee(1);
            //ViewData["EmployeeHeader"] = "Employee Data";
            //ViewData["Employee"] = emp;

            //ViewBag.EmployeeHeader = "Employee Data";
            //ViewBag.Employee = emp;

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee= employee,
                 PageTitle= "Employee Data"
            };

            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int Id)
        {
          Employee  Employee = _employeeRepository.GetEmployee(Id);

            EmployeeEditViewModel editViewModel = new EmployeeEditViewModel
              { Id = Employee.Id,
              Name=Employee.Name,
              Department=Employee.Department,
              Email=Employee.Email,
              ExistingPhotoPath=Employee.PhotoPath

            };

            return View(editViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                Employee Employee = _employeeRepository.GetEmployee(model.Id);
                Employee.Name = model.Name;
                Employee.Department = model.Department;
                Employee.Email = model.Email;

                if (model.Photo != null)
                {
                    Employee.PhotoPath = ProcessUploadFile(model);
                }

           

                Employee _employee = _employeeRepository.Update(Employee);
            
            }
            return RedirectToAction("Index");


        }

        private string ProcessUploadFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {

                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var filestream = new FileStream(filePath, FileMode.Create))
                { model.Photo.CopyTo(filestream); }
            }

            return uniqueFileName;
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                string uniqueFileName = ProcessUploadFile(model);
             
                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email=model.Email,
                    Department=model.Department,
                    PhotoPath=uniqueFileName
                };
                Employee _employee = _employeeRepository.Add(newEmployee);
                return RedirectToAction("Details", new { id = _employee.Id });
            }
          
                return View();
           
        }
    }
}
