using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Models
{
    public class SSpeaker
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Session ID")]
        public int SessionId { get; set; }

        [ForeignKey("SessionId")]
        public Sessions Sessions { get; set; }

        [Display(Name = "Speaker ID")]
        public int? SpeakerId { get; set; }

        [ForeignKey("SpeakerId")]
        public Speakers Speakers { get; set; }
    }
}
