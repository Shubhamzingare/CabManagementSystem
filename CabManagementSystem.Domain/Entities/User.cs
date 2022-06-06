using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabManagementSystem.Domain.Entities
{
    public class User
    {
        [Key]

        [Required(ErrorMessage = "First name field can't be empty ")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last name field can't be empty")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "User type field can't be empty")]
        [Display(Name = "User Type")]
        public string UserType { get; set; }


        [Required(ErrorMessage = "Email field can't be empty")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid type")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Username field can't be empty")]
        [Display(Name = "Username")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Password field can't be empty")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Confirm Password field can't be empty")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Compare Password fields are not matching, enter again")]
        public string ConfirmPassword { get; set; }
    }
}
