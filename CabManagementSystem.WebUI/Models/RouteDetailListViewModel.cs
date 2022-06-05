using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CabManagementSystem.Domain.Entities;

namespace CabManagementSystem.WebUI.Models
{
    public class RouteDetailListViewModel
    {
        public BatchDetail BatchDetails { get; set; }
        public RouteDetail RouteDetails { get; set; }

    }
}