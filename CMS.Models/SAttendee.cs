using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Models
{
    public class SAttendee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Session ID")]
        public int SessionId { get; set; }

        [ForeignKey("SessionId")]
        public Sessions Sessions { get; set; }

        [Display(Name = "Attendee ID")]
        public int? AttendeeId { get; set; }

        [ForeignKey("AttendeeId")]
        public Attendees Attendees { get; set; }
    }
}
