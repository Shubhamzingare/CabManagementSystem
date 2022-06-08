using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CabManagementSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CabManagementSystem.WebUI.Models
{
    public class TripListViewModel
    {
        [Key]
        public Trip TripSheet { get; set; }
        public VehicleDetail VehicleDetails { get; set; }
        public PagingInfo PagingInfo { get; set; }
        
    }
}