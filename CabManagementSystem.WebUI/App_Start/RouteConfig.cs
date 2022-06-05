using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CabManagementSystem.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "", new { controller = "Employee", action = "List" });

            routes.MapRoute(null, "", new { controller = "Employee", action = "List", page = 1 });

            routes.MapRoute(null, "Page{page}", new { controller = "Employee", action = "List" }, new { page = @"\d+" });

            routes.MapRoute(null, "", new { controller = "RouteDetail", action = "RouteDetailsById" });


            routes.MapRoute(null, "", new { controller = "ShiftTiming", action = "ShiftTimingList" });

            routes.MapRoute(null, "", new { controller = "ShiftTiming", action = "ShiftTimingList", page = 1 });

            routes.MapRoute(null, "Page{page}", new { controller = "ShiftTiming", action = "ShiftTimingList" }, new { page = @"\d+" });


            routes.MapRoute(null, "", new { controller = "BatchDetail", action = "BatchDetailList" });

            routes.MapRoute(null, "", new { controller = "BatchDetail", action = "BatchDetailList", page = 1 });

            routes.MapRoute(null, "Page{page}", new { controller = "BatchDetail", action = "BatchDetailList" }, new { page = @"\d+" });


            routes.MapRoute(null, "", new { controller = "VehicleDetail", action = "VehicleDetailList" });

            routes.MapRoute(null, "", new { controller = "VehicleDetail", action = "VehicleDetailList", page = 1 });

            routes.MapRoute(null, "Page{page}", new { controller = "VehicleDetail", action = "VehicleDetailList" }, new { page = @"\d+" });

            //By Page url like Page1/VehicleDetail/VehicleDetailList

            routes.MapRoute(null, "{controller}/{action}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",

                defaults: new { controller = "Trip", action = "List", id = UrlParameter.Optional }
            
            );
        }
    }
}
