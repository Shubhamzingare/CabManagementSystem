using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CabManagementSystem.Domain.Entities
{
    public class Trip
    {
        [Key]
        public int id { get; set; }
        public string tripSheetId { get; set; }

        public string vehicleAlloId { get; set; }

        public string vehicleId { get; set; }
        public int ratePerKM { get; set; }

        [Required(ErrorMessage = "Please enter distance travelled in kms")]
        public decimal distanceTravelled { get; set; }

        public string Remark { get; set; }
    }
}

