using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CabManagementSystem.Domain.Entities;
using CabManagementSystem.Domain.Concrete;
using CabManagementSystem.WebUI.Models;
namespace CabManagementSystem.WebUI.Controllers
{
  
    public class ShiftDetailController : Controller
    {


        private CabDbContext context = new CabDbContext();

       
        public ActionResult ShiftDetailsByID()
        {
            int id = Convert.ToInt32(Request["searchID"]);
            
            List<ShiftTiming> shiftTimings = context.ShiftTimings.ToList();
            List<RouteDetail> routeDetails = context.RouteDetails.ToList();
            List<BatchDetail> batchDetails = context.BatchDetails.ToList();

            var Details = from s in shiftTimings
                          join b in batchDetails on s.shiftId equals b.shiftId
                          into table1
                          from b in table1.ToList()
                          join r in routeDetails on b.batchId equals r.batchId into table2
                          from r in table2.ToList()
                          where s.shiftId == id
                          select new ShiftDetailViewModel
                          {
                              RouteDetails = r,
                              BatchDetails = b,
                              ShiftTimings = s
                          };
            return View(Details);
        }

    }
}