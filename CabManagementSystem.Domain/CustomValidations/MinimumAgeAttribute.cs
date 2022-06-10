using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabManagementSystem.Domain.Entities;
namespace CabManagementSystem.Domain.CustomValidations
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
           
        }
        
        public override bool IsValid(object value)
        {
            DateTime DOB;
            if (DateTime.TryParse(value.ToString(), out DOB))
            {
                return DOB.AddYears(_minimumAge) < DateTime.Now;
            }

            return false;
        }
       
    }
}