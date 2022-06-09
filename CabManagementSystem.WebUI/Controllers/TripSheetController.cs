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
    public class TripSheetController : Controller
    {

        public CabDbContext context = new CabDbContext();
        //private IVehicleBillRepository repository;

        //public int PageSize = 3;
        //public TripSheetController(IVehicleBillRepository repo)
        //{
        //    this.repository = repo;
        //}
        //public ActionResult TripSheet()
        //{
        //    List<VehicleBill> vehicleBills = context.VehicleBills.ToList();
        //    List<VehicleDetail> vehicleDetails = context.VehicleDetails.ToList();
        //    List<TripSheet> tripSheets = context.TripSheets.ToList();

        //    var Details = from t in tripSheets
        //                  join v in vehicleDetails on t.vehicleId equals v.vehicleId
        //                  into table1
        //                  from v in table1.ToList()
        //                  join vb in vehicleBills on t.vehicleId equals vb.vehicleId
        //                  into table2
        //                  from vb in table2.ToList()
        //                  select new TripSheetViewModel
        //                  {
        //                      TripSheets = t,
        //                      VehicleDetails = v,
        //                      VehicleBills = vb

        //                  };
                          
        //    return View(Details);
        //}

    }
}