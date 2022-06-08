using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CabManagementSystem.WebUI.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        
        [AllowAnonymous]
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
        [AllowAnonymous]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "User");
        }


    }
}