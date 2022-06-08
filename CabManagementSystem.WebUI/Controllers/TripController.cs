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
    public class TripController : Controller
    {
        CabDbContext db = new CabDbContext();

        private ITripRepository repository;

        public int PageSize = 3;
        public TripController(ITripRepository repo)
        {
            this.repository = repo;
        }

        public ViewResult List(int page = 1)
        {
            int rate = Convert.ToInt32(Request["ID"]);
            List<Trip> TripSheet = db.TripSheet.ToList();
            List<VehicleDetail> VehicleDetails = db.VehicleDetails.ToList();
            var Details = from t in TripSheet
                          join v in VehicleDetails on t.ratePerKM
                          equals v.ratePerKM into table1
                          from v in table1.ToList()
                          where (v.ratePerKM == rate)
                          select new TripListViewModel
                          {
                              TripSheet = t,
                              VehicleDetails = v
                          };
            return View(Details);
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(Trip trip)
        {
            if (ModelState.IsValid)
            {
                db.TripSheet.Add(trip);
                db.SaveChanges();
                return RedirectToAction("List");
            }

            return View(trip);
        }
    }
}