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
    public class VehicleDetailController : Controller
    {
         CabDbContext db = new CabDbContext();
        private IVehicleDetailRepository repository;

        public int PageSize = 3;

        public VehicleDetailController(IVehicleDetailRepository repo)
        {
            this.repository = repo;
        }
        public ViewResult VehicleDetailList(int page = 1)
        {
            VehicleDetailListViewModel model = new VehicleDetailListViewModel
            {
                VehicleDetails = repository.VehicleDetails
                 .OrderBy(p => p.vehicleId)
                                .Skip((page - 1) * PageSize)
                                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.VehicleDetails.Count()
                }

            };
            return View(model);
        }
        public ViewResult Edit(int id)
        {
            VehicleDetail vehicleDetail= repository.VehicleDetails.FirstOrDefault(p => p.vehicleId == id);
            return View(vehicleDetail);
        }
        [HttpPost]
        public ActionResult Edit(VehicleDetail vehicleDetail)
        {
            if (ModelState.IsValid)
            {
                repository.SaveVehicle(vehicleDetail);
                TempData["message"] = string.Format("{0} has been saved to database.", vehicleDetail.vehicleName);
                return RedirectToAction("VehicleDetailList");
            }
            else
            {
                return View(vehicleDetail);
            }
        }
        public ActionResult Create(VehicleDetail vehicleDetail)
        {
            if (ModelState.IsValid)
            {
                db.VehicleDetails.Add(vehicleDetail);
                db.SaveChanges();
                return RedirectToAction("VehicleDetailList");
            }

            return View(vehicleDetail);
        }
        public ActionResult Delete(int id)
        {
            VehicleDetail vehicleDetail = db.VehicleDetails.Find(id);
            db.VehicleDetails.Remove(vehicleDetail);
            db.SaveChanges();
            return RedirectToAction("VehicleDetailList");

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