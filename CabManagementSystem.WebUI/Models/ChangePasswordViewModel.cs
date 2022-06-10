using CabManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CabManagementSystem.WebUI.Models
{
    public class ChangePasswordViewModel
    {
        [Key]
        public IEnumerable<User> Users { get; set; }

        [Required(ErrorMessage = "Current Password can't be empty")]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "New Password can't be empty")]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm New Password can't be empty")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm New password")]
        [Compare("NewPassword",ErrorMessage = "New password and confirm password are not matching")]
        public string ConfirmNewPassword { get; set; }
    }
}