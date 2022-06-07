
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CabManagementSystem.WebUI.Models;
using CabManagementSystem.Domain.Concrete;
using CabManagementSystem.Domain.Entities;
using CabManagementSystem.Domain.Abstract;



namespace CabManagementSystem.WebUI.Controllers
{
    public class RouteDetailController : Controller
    {
        private IRouteDetailRepository repository;

        public RouteDetailController(IRouteDetailRepository repo)
        {
            this.repository = repo;
        }

        private CabDbContext db = new CabDbContext();


        public ViewResult RouteDetailsById()
        {
            int id = Convert.ToInt32(Request["ID"]);
            List<RouteDetail> routeDetails = db.RouteDetails.ToList();
            List<BatchDetail> batchDetails = db.BatchDetails.ToList();
            var Details = from r in routeDetails
                          join b in batchDetails on r.routeId
                          equals b.batchId into table1
                          from b in table1.ToList()
                          where (r.routeId == id)
                          select new RouteDetailListViewModel
                          {
                              RouteDetails = r,
                              BatchDetails = b
                          };
            return View(Details);


        }

        public ViewResult Edit(int id)
        {
            RouteDetail routeDetail = repository.RouteDetails.FirstOrDefault(p => p.routeId == id);
            return View(routeDetail);
        }
        [HttpPost]
        public ActionResult Edit(RouteDetail routeDetail)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRoute(routeDetail);
                TempData["message"] = string.Format("{0} has been saved to database.", routeDetail.routeId);
                return RedirectToAction("RouteDetailsById");
            }
            else
            {
                return View(routeDetail);
            }
        }
        public ActionResult Create(RouteDetail routeDetail)
        {
            if (ModelState.IsValid)
            {
                db.RouteDetails.Add(routeDetail);
                db.SaveChanges();
                return RedirectToAction("RouteDetailsById");
            }

            return View(routeDetail);
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
