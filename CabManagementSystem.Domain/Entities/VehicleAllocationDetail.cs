using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CabManagementSystem.Domain.Entities
{
    public class VehicleAllocationDetail
    {
        [Key]
        public int vehicleAlloId { get; set; }
        public int vehicleId { get; set; }
        public int empId { get; set; }
        public int driverId { get; set; }
        public string PickOrDrop { get; set; }
        public int routeId { get; set; }
    }
}
