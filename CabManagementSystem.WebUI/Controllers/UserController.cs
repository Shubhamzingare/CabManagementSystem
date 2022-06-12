using CabManagementSystem.Domain.Concrete;
using CabManagementSystem.Domain.Entities;
using CabManagementSystem.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CabManagementSystem.WebUI.Controllers
{
    public class UserController : Controller
    {
        CabDbContext context = new CabDbContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Domain.Entities.User user)
        {
            var userData = context.Users.Where(model => model.UserType == user.UserType &&
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
                context.Users.Add(user);
                int a = context.SaveChanges();
                if (a > 0)
                {
                    ViewBag.InsertMessage = "<script>alert('Registered Successfully')</script>";
                    ModelState.Clear();
                    return RedirectToAction("Index");
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
