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

        public Speakers Speakers { get; set; }

        public Sessions Sessions { get; set; }

        public Tags Tags { get; set; }

        public SSpeaker SSpeaker { get; set; }

        public STag STag { get; set; }

        public SAttendee SAttendee { get; set; }

        //DropDownLists
        public IEnumerable<SelectListItem> ConferenceList { get; set; }

        public IEnumerable<SelectListItem> TracksList { get; set; }

        public IEnumerable<SelectListItem> AttendeesList { get; set; }

        public IEnumerable<SelectListItem> SpeakersList { get; set; }

        public IEnumerable<SelectListItem> SessionsList { get; set; }

        public IEnumerable<SelectListItem> TagsList { get; set; }
    }
}
