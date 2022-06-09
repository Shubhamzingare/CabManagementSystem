using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CabManagementSystem.Domain.Entities;

namespace CabManagementSystem.WebUI.Models
{
    public class VehicleAllocationViewModel
    {
        public IEnumerable<VehicleAllocationDetail> VehicleAllocations { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}