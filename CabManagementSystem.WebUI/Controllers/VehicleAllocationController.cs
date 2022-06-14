using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CabManagementSystem.Domain.Concrete;
using CabManagementSystem.Domain.Entities;
using CabManagementSystem.Domain.Abstract;
using CabManagementSystem.WebUI.Models;
namespace CabManagementSystem.WebUI.Controllers
{
    [CustomAuthenticationFilter]
    public class VehicleAllocationController : Controller
    {
        CabDbContext db = new CabDbContext();

        public int PageSize = 3;

        private IVehicleAllocationRepository repository;

        public VehicleAllocationController(IVehicleAllocationRepository repo)
        {
                this.repository = repo;
        }

        public ViewResult VehicleAllocationList(int page = 1)
        {
            VehicleAllocationViewModel model = new VehicleAllocationViewModel
            {
                VehicleAllocations = repository.VehicleAllocations
                 .OrderBy(p => p.vehicleId)
                                .Skip((page - 1) * PageSize)
                                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.VehicleAllocations.Count()
                }

            };
            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VehicleAllocationDetail vehicleAllocation)
        {
            if (ModelState.IsValid)
            {
                db.VehicleAllocations.Add(vehicleAllocation);
                db.SaveChanges();
                return RedirectToAction("VehicleAllocationList");
            }

            return View(vehicleAllocation);
        }
    }
}