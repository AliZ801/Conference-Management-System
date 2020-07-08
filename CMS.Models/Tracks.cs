using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Models
{
    public class Tracks
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Track Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Conference ID")]
        public int ConferenceId { get; set; }

        [ForeignKey("ConferenceId")]
        public Conference Conference { get; set; }
    }
}
