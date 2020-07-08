using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMS.Models
{
    public class Conference
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Conference Name")]
        public string Name { get; set; }
    }
}
