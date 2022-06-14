using CabManagementSystem.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CabManagementSystem.WebUI.Controllers
{
    [CustomAuthenticationFilter]
    public class DashboardController : Controller
    {
        
        public ActionResult UserDashboard()
        {
            if (Session["UserType"] == null)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "User");
        }


    }
}