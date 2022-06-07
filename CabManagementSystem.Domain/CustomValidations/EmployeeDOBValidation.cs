using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabManagementSystem.Domain.Entities;
namespace CabManagementSystem.Domain.CustomValidations
{
    public class EmployeeDOBValidation : ValidationAttribute
    {
        int _minimumAge;

        public EmployeeDOBValidation(int minimumAge=18)
        {
            _minimumAge = minimumAge;
        }

        public override bool IsValid(object value)
        {
            DateTime date;
            if (DateTime.TryParse(value.ToString(), out date))
            {
                return date.AddYears(_minimumAge) < DateTime.Now;
            }

            return false;
        }
       
    }
}
//