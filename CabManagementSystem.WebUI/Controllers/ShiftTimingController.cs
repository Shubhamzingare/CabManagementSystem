using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CabManagementSystem.Domain.Entities;
using CabManagementSystem.Domain.Abstract;
using CabManagementSystem.Domain.Concrete;
using CabManagementSystem.WebUI.HtmlHelpers;
using CabManagementSystem.WebUI.Models;
using System.Net;

namespace CabManagementSystem.WebUI.Controllers
{
    public class ShiftTimingController : Controller
    {
        //Prepare for DI
        private IShiftTimingsRepository repository;

        CabDbContext db = new CabDbContext();

        public int PageSize = 2;
        public ShiftTimingController(IShiftTimingsRepository repo)
        {
            this.repository = repo;
        }

        public ViewResult ShiftTimingList(int page = 1)
        {
            ShiftTimingListViewModel model = new ShiftTimingListViewModel
            {
                ShiftTimings = repository.ShiftTimings
                 .OrderBy(p => p.shiftId)
                          .Skip((page - 1) * PageSize)
                          .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.ShiftTimings.Count()
                }
            };
            return View(model);
        }

        public ViewResult Edit(int id)
        {
            ShiftTiming shiftTiming = repository.ShiftTimings.FirstOrDefault(p => p.shiftId == id);
            return View(shiftTiming);
        }
        [HttpPost]
        public ActionResult Edit(ShiftTiming shiftTiming)
        {
            if (ModelState.IsValid)
            {
                repository.SaveShift(shiftTiming);
                TempData["message"] = string.Format("{0} has been saved to database.", shiftTiming.ShiftName);
                return RedirectToAction("ShiftTimingList");
            }
            else
            {
                return View(shiftTiming);
            }
        }
        public ActionResult Create(ShiftTiming shiftTiming)
        {
            if (ModelState.IsValid)
            {
                db.ShiftTimings.Add(shiftTiming);
                db.SaveChanges();
                return RedirectToAction("ShiftTimingList");
            }

            return View(shiftTiming);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}