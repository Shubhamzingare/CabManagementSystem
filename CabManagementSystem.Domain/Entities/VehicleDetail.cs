using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CabManagementSystem.Domain.Entities
{
    public class VehicleDetail
    {
        [Key]
        [Required(ErrorMessage = "Please enter ID")]
        public int vehicleId { get; set; }


        [Required(ErrorMessage = "Please enter a Vehicle name")]
        public string vehicleName { get; set; }
        public int venderId { get; set; }
        public int driverId { get; set; }
        public string vehicleType { get; set; }


        [Required(ErrorMessage = "Please enter a Vehicle Number")]
        public string vehicleNum { get; set; }


        [Required(ErrorMessage = "Please enter rate per KM")]
        public int ratePerKM { get; set; }
        public int capacity { get; set; }
        public int routeId { get; set; }
    }
}
