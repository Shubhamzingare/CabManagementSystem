using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CabManagementSystem.Domain.Entities;
using CabManagementSystem.Domain.Abstract;
using CabManagementSystem.Domain.Concrete;
using CabManagementSystem.WebUI.Models;

namespace CabManagementSystem.WebUI.Controllers
{
    public class BatchDetailController : Controller
    {
        CabDbContext db = new CabDbContext();

        private IBatchDetailRepository repository;
        public int PageSize = 1;
        public BatchDetailController(IBatchDetailRepository repo)
        {
            this.repository = repo;
        }
        public ViewResult BatchDetailList(int page = 1)
        {
            BatchDetailViewModel model = new BatchDetailViewModel
            {
                BatchDetails = repository.BatchDetails
                .OrderBy(p => p.batchId)
                                .Skip((page - 1) * PageSize)
                                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.BatchDetails.Count()
                }
            };
            return View(model);
        }
        public ViewResult Edit(int id)
        {
            BatchDetail batchDetail = repository.BatchDetails.FirstOrDefault(p => p.batchId == id);
            return View(batchDetail);
        }
        [HttpPost]
        public ActionResult Edit(BatchDetail batchDetail)
        {
            if (ModelState.IsValid)
            {
                repository.SaveBatch(batchDetail);
                TempData["message"] = string.Format("{0} has been saved to database.", batchDetail.batchId);
                return RedirectToAction("BatchDetailList");
            }
            else
            {
                return View(batchDetail);
            }
        }
        public ActionResult Create(BatchDetail batchDetail)
        {
            if (ModelState.IsValid)
            {
                db.BatchDetails.Add(batchDetail);
                db.SaveChanges();
                return RedirectToAction("BatchDetailList");
            }

            return View(batchDetail);
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