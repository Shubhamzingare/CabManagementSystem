using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CabManagementSystem.Domain.Entities;
namespace CabManagementSystem.WebUI.Models
{
    public class VehicleBillViewModel
    {
        public VehicleBill VehicleBills { get; set; }
        public VehicleDetail VehicleDetails { get; set; }
        public TripSheet TripSheets { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}