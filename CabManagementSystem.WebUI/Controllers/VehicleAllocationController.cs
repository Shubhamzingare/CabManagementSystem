using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CabManagementSystem.Domain.Abstract;
using CabManagementSystem.Domain.Concrete;
using CabManagementSystem.Domain.Entities;
using CabManagementSystem.WebUI.Models;

namespace CabManagementSystem.WebUI.Controllers
{
    public class VehicleAllocationController : Controller
    {
        // GET: VehicleAllocation

        CabDbContext db = new CabDbContext();

        public int PageSize = 3;

        private IVehicleAllocationRepository repository;

        public VehicleAllocationController(IVehicleAllocationRepository repo)
        {
            this.repository = repo;
        }

        public ViewResult list(int page = 1)
        {
            VehicalAllocationListViewModel model = new VehicalAllocationListViewModel
            {
                VehicleAllocationDetails = repository.VehicleAllocationDetails
                 .OrderBy(p => p.vehicleId)
                                .Skip((page - 1) * PageSize)
                                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.VehicleAllocationDetails.Count()
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
        public ActionResult Create(VehicleAllocationDetail VehicleDetail)
        {
            if (ModelState.IsValid)
            {
                db.VehicleAllocationDetails.Add(VehicleDetail);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(VehicleDetail);
        }
    }
}