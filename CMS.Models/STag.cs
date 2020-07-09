using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Models
{
    public class STag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Session ID")]
        public int SessionId { get; set; }

        [ForeignKey("SessionId")]
        public Sessions Sessions { get; set; }

        [Display(Name = "Tag ID")]
        public int? TagId { get; set; }

        [ForeignKey("TagId")]
        public Tags Tags { get; set; }
    }
}
