using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabManagementSystem.Domain.Entities
{
    public class VehicleBill
    {
        [Key]
        public int billId { get; set; }
        public int billNum { get; set; }
        public int vehicleId { get; set; }
        [Required]
        public DateTime dateOfBilling { get; set; }
        public int venderId { get; set; }
        public decimal deductions { get; set; }
    }
}
