using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Models
{
    public class Sessions
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public string STime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public string ETime { get; set; }

        [Required]
        [Display(Name = "Conference ID")]
        public int ConferenceId { get; set; }

        [ForeignKey("ConferenceId")]
        public Conference Conference { get; set; }

        [Display(Name = "Track ID")]
        public int? TrackId { get; set; }

        [ForeignKey("TrackId")]
        public Tracks Tracks { get; set; }
    }
}
