using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CabManagementSystem.Domain.Entities
{
    public class BatchDetail
    {
        [Key]
        [Required]
        public int batchId { get; set; }
        public int totalEmp { get; set; }

        [Required]
        public int shiftId { get; set; }
    }
}
