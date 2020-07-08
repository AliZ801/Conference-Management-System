using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Models.ViewModel
{
    public class CMSViewModel
    {
        public Conference Conference { get; set; }

        public Tracks Tracks { get; set; }

        public Attendees Attendees { get; set; }

        public ConfAttendees ConfAttendees { get; set; }

        //DropDownLists
        public IEnumerable<SelectListItem> ConferenceList { get; set; }

        public IEnumerable<SelectListItem> TracksList { get; set; }

        public IEnumerable<SelectListItem> AttendeesList { get; set; }
    }
}
