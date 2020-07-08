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

        void Save();
    }
}
