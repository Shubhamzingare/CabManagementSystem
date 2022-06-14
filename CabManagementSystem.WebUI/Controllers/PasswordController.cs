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
    [CustomAuthenticationFilter]
    public class PasswordController : Controller
    {
        CabDbContext context = new CabDbContext();
        public ActionResult ChangePassword()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Index");
            }
            else { }
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(string Password, string newPassword, string Confirmpwd)
        {
            
            User user = new User();
            string username = Session["UserName"].ToString();
            var usertype = Session["UserType"].ToString();
            var data = context.Users.Where(u => u.UserName.Equals(username) && u.UserType.Equals(usertype)).FirstOrDefault();
            if (data.Password == Password)
            {
                if (Confirmpwd == newPassword)
                {
                    data.ConfirmPassword = Confirmpwd;
                    data.Password = newPassword;
                    context.Entry(data).State = EntityState.Modified;
                    context.SaveChanges();
                    TempData["msg"] = "<script>alert('Password has been changed successfully !!!');</script>";
                }
                else
                {
                    TempData["msg"] = "<script>alert('New password and confirm password don't match !!! Please check');</script>";
                }
            }
            else
            {
                TempData["msg"] = "<script>alert('Old password not match !!! Please check entered old password');</script>";
            }
            return View();
        }
    }
}