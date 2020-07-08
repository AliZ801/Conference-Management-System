using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMS.Models
{
    public class Attendees
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FName { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
