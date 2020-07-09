using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.DataAccess.Data.IRepository
{
    public interface IUnitofWork : IDisposable
    {
        IConferenceRepo Conference { get; }

        ITracksRepo Tracks { get; }

        IAttendeesRepo Attendees { get; }

        IConfAttendeeRepo ConfAttendee { get; }

        IUserRepo User { get; }

        ISpeakersRepo Speakers { get; }

        ISessionsRepo Sessions { get; }

        ITagsRepo Tags { get; }

        ISSpeakerRepo SSpeaker { get; }

        ISTagRepo STag { get; }

        ISAttendeeRepo SAttendee { get; }

        void Save();
    }
}
