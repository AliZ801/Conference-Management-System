using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMS.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Verification ID")]
        public string VerfID { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LName { get; set; }
    }
}
