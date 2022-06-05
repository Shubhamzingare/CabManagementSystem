using CabManagementSystem.WebUI.Models.UserDbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CabManagementSystem.WebUI.Controllers
{
    public class UserController : Controller
    {
        CabManagementSystemEntities db = new CabManagementSystemEntities();
        //GET : login 
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            var userData = db.Users.Where(model => model.UserType == user.UserType &&
                                        model.UserName == user.UserName &&
                                        model.Password == user.Password).FirstOrDefault();
            if (userData != null)
            {
                Session["UserType"] = user.UserType;
                Session["UserName"] = user.UserName.ToString();
                TempData["LoginSuccessMessage"] = "<script>alert('Login Succesful!')</script>";
                return RedirectToAction("UserDashboard", "Dashboard");
            }
            else
            {
                ViewBag.ErrorMessage = "<script>alert('Login Failed! Username/Password is incorrect')</script>";
                return View();
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid == true)
            {
                db.Users.Add(user);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.InsertMessage = "<script>alert('Registered Successfully')</script>";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Registration Failed! Try again')</script>";
                }
            }
            return View();
        }
    }
}