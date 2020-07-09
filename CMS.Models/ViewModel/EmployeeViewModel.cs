using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Models.ViewModel
{
    public class EmployeeViewModel
    {
        public IEnumerable<Conference> Conference { get; set; }

        public IEnumerable<Tracks> Tracks { get; set; }

        public IEnumerable<Speakers> Speakers { get; set; }

        public IEnumerable<Sessions> Sessions { get; set; }

        public IEnumerable<SSpeaker> SSpeakers { get; set; }

        public IEnumerable<Tags> Tags { get; set; }

        public IEnumerable<STag> STag { get; set; }

        public IEnumerable<Attendees> Attendees { get; set; }

        public IEnumerable<ConfAttendees> ConfAttendees { get; set; }

        public IEnumerable<SAttendee> SAttendees { get; set; }
    }
}
