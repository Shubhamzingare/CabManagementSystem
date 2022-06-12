using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CabManagementSystem.Domain.CustomValidations;

namespace CabManagementSystem.Domain.Entities
{
    public class Employee
    {

        [Key]
        [Required]
        public int empId { get; set; }

        [Required(ErrorMessage = "Please enter a employee name")]
        public string empName { get; set; }

        [Required(ErrorMessage = "Please enter Permanent Address")]

        public string perAddress { get; set; }

        public string comAddress { get; set; }

        public string qualification { get; set; }

       
        [DataType(DataType.Date)]
        [MinimumAge((18),ErrorMessage =("Date of birth must be at least 18 years from current date")) ]
        [Required(ErrorMessage = "Please enter Date of Birth")]
        public DateTime DOB { get; set; }

        public string vehrequired { get; set; }

        public string gender { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please enter Phone number!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string phoneNo { get; set; }


        public string designation { get; set; }


        public string department { get; set; }

        [Required(ErrorMessage = "Please enter Date of Joining")]

        [EmployeeDOJValidation]
        [DataType(DataType.Date)]
        public DateTime DOJ { get; set; }

        public enum required
        {
            Yes,
            No
        }

    }
}
