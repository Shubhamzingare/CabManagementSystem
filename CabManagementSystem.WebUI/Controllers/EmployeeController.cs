using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CabManagementSystem.Domain.Entities;
using CabManagementSystem.Domain.Abstract;
using CabManagementSystem.Domain.Concrete;
using CabManagementSystem.WebUI.Models;
using System.Net;

namespace CabManagementSystem.WebUI.Controllers
{
    [CustomAuthenticationFilter]
    public class EmployeeController : Controller
    {
        CabDbContext db = new CabDbContext();

        private IEmployeeRepository repository;

        public int PageSize = 3;
        public EmployeeController(IEmployeeRepository repo)
        {
            this.repository = repo;
        }


        public ViewResult List(int page = 1)
        {
            EmployeeListViewModel model = new EmployeeListViewModel
            {
                Employees = repository.Employees
                                .OrderBy(p => p.empId)
                                .Skip((page - 1) * PageSize)
                                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Employees.Count()
                }
            };
            return View(model);
        }

        public ViewResult Edit(int id)
        {
            Employee employee = repository.Employees.FirstOrDefault(p => p.empId == id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                repository.SaveEmployee(employee);
                TempData["message"] = string.Format("{0} has been saved to database.", employee.empName);
                return RedirectToAction("List");
            }
            else
            {
                return View(employee);
            }
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("List");
            }

            return View(employee);
        }

        public ActionResult Delete(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("List");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}