
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CabManagementSystem.WebUI.Models;
using CabManagementSystem.Domain.Concrete;
using CabManagementSystem.Domain.Entities;


namespace CabManagementSystem.WebUI.Controllers
{
    public class RouteDetailController : Controller
    {

        private CabDbContext context = new CabDbContext();

        //public ActionResult Edit(RouteDetail routeDetails)
        //{
        //    var
        //}
        public ActionResult RouteDetailsById()
        {
            int id = Convert.ToInt32(Request["ID"]);
            List<RouteDetail> routeDetails = context.RouteDetails.ToList();
            List<BatchDetail> batchDetails = context.BatchDetails.ToList();
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
    }
}
