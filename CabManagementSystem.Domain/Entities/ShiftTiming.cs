using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CabManagementSystem.Domain.Entities
{
    public class ShiftTiming
    {
        [Key]
        [Required]
        public int shiftId { get; set; }

        [Required(ErrorMessage = "Please enter a shift name")]
        public string ShiftName { get; set; }

        [Required(ErrorMessage = "Please enter start time")]
        [DataType(DataType.Time)]
        public DateTime shiftStartTime { get; set; }

        [Required(ErrorMessage = "Please enter end time")]
        [DataType(DataType.Time)]
        public DateTime shiftEndTime { get; set; }

        [Range(1, Int32.MaxValue)]
        public int totalBatches { get; set; }

    }
    public enum Shifts
    {
        Morning,
        Afternoon,
        Evening,
        Night
    }
}
