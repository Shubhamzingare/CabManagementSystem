using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabManagementSystem.Domain.Entities
{
    public class VehicleAllocation
    {
        [Key]
        public int vehicleAlloId { get; set; }
        public int vehicleId { get; set; }
        public int empId { get; set; }
        public int driverId { get; set; }
        public string pickOrDrop { get; set; }
        public int routeId { get; set; }
    }
}
