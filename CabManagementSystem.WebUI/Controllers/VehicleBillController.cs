using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CabManagementSystem.Domain.Entities;
using CabManagementSystem.Domain.Concrete;
using CabManagementSystem.WebUI.Models;
using CabManagementSystem.Domain.Abstract;

namespace CabManagementSystem.WebUI.Controllers
{
    public class VehicleBillController : Controller
    {
        public CabDbContext context = new CabDbContext();
        private IVehicleBillRepository repository;

        public int PageSize = 3;
        public VehicleBillController(IVehicleBillRepository repo)
        {
            this.repository = repo;
        }
        public ActionResult VehicleBillList()
        {
            List<VehicleBill> vehicleBills = context.VehicleBills.ToList();
            List<VehicleDetail> vehicleDetails = context.VehicleDetails.ToList();
            List<TripSheet> tripSheets = context.TripSheets.ToList();

            var Details = from t in tripSheets
                          join v in vehicleDetails on t.vehicleId equals v.vehicleId
                          into table1
                          from v in table1.ToList()
                          join vb in vehicleBills on t.vehicleId equals vb.vehicleId
                          into table2
                          from vb in table2.ToList()                          
                          
                          select new VehicleBillViewModel
                          {
                              TripSheets = t,
                              VehicleDetails = v,
                              VehicleBills = vb

                          };

            return View(Details);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        //[AllowAnonymous]
        public ActionResult Create(VehicleBill vehicleBill)
        {
            if (ModelState.IsValid)
            {
                context.VehicleBills.Add(vehicleBill);
                context.SaveChanges();
                return RedirectToAction("VehicleBillList");
            }

            return View(vehicleBill);
        }
        //[AllowAnonymous]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}