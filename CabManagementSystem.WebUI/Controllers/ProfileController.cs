using CabManagementSystem.Domain.Concrete;
using CabManagementSystem.Domain.Entities;
using CabManagementSystem.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CabManagementSystem.WebUI.Controllers
{
    [CustomAuthenticationFilter]
    public class ProfileController : Controller
    {
        CabDbContext context = new CabDbContext();

        public ActionResult ViewProfile(User user)
        {
            var username = Convert.ToString(Session["UserName"]);
            var userdata = context.Users.Where(p => p.UserName == username).ToList();

            return View(userdata);
        }
        
    }
}