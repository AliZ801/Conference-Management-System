using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Models
{
    public class ConfAttendees
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Conference ID")]
        public int ConferenceId { get; set; }

        [ForeignKey("ConferenceId")]
        public Conference Conference { get; set; }

        [Required]
        [Display(Name = "Attendee ID")]
        public int AttendeeId { get; set; }

        [ForeignKey("AttendeeId")]
        public Attendees Attendees { get; set; }
    }
}
