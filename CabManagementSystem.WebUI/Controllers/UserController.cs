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
        public ActionResult Index(User user)
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


        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            //User user = null;
            //    var uname = Session["UserName"];
            //    user = context.Users.Find(uname);
            //    if (user.Password == model.CurrentPassword)
            //    {
            //        user.Password = model.CurrentPassword;
            //        context.Entry(user).State = EntityState.Modified;
            //        context.SaveChanges();
            //        ViewBag.InsertMessage = "Your Password is updated successfully";
            //    }
            //    else
            //    {
            //        ViewBag.InsertMessage = "Invalid Current Password";
            //    }

            //return View();


            try
            {

                var data = context.Users.Where( u => u.Password == model.ConfirmNewPassword).FirstOrDefault();
                if(data != null)
                {
                    data.Password = model.NewPassword;
                    context.SaveChanges();

                    TempData["msg"] = "Password updated successfully";
                }
                else
                {
                    TempData["msg"] = "Password not updated";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex;
            }
            return View();
        }
    }
}