using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabManagementSystem.Domain.Entities
{
    public class VehicleAllocation
    {
        public string vehicleAlloId { get; set; }
        public string vehicleId { get; set; }
        public string empId { get; set; }
        public string driverId { get; set; }
        public string pickOrDrop { get; set; }
        public string routeId { get; set; }
    }
}
