using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CabManagementSystem.Domain.Entities;
using CabManagementSystem.Domain.Abstract;
using CabManagementSystem.Domain.Concrete;
using CabManagementSystem.WebUI.Models;
using System.Net;

namespace CabManagementSystem.WebUI.Controllers
{
    public class TripController : Controller
    {
        CabDbContext db = new CabDbContext();

        private ITripRepository repository;

        public int PageSize = 3;
        public TripController(ITripRepository repo)
        {
            this.repository = repo;
        }

        public ViewResult List(int page = 1)
        {
            TripListViewModel model = new TripListViewModel
            {
                TripSheet = repository.TripSheet
                            .OrderBy(t => t.tripSheetId)
                                .Skip((page - 1) * PageSize)
                                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.TripSheet.Count()
                }
            };
            return View(model);
        }
    }
}