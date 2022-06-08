using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CabManagementSystem.Domain.Entities
{
    public class TripSheet
    {
        [Key]
        [Required]
        public int tripSheetId { get; set; }

        public int vehicleAlloId { get; set; }

        public int vehicleId { get; set; }

        [Required(ErrorMessage = "Please enter distance travelled in kms")]
        public int distanceTravelled { get; set; }

        public string remark { get; set; }
    }
}

