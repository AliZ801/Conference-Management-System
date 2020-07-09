using CMS.DataAccess.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.DataAccess.Data.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext _db;

        public UnitofWork(ApplicationDbContext db)
        {
            _db = db;
            Conference = new ConferenceRepo(_db);
            Tracks = new TracksRepo(_db);
            Attendees = new AttendeesRepo(_db);
            ConfAttendee = new ConfAttendeeRepo(_db);
            User = new UserRepo(_db);
            Speakers = new SpeakersRepo(_db);
            Sessions = new SessionsRepo(_db);
            Tags = new TagsRepo(_db);
            SSpeaker = new SSpeakerRepo(_db);
            STag = new STagRepo(_db);
            SAttendee = new SAttendeeRepo(_db);
        }

        public IConferenceRepo Conference { get; private set; }

        public ITracksRepo Tracks { get; private set; }

        public IAttendeesRepo Attendees { get; private set; }

        public IConfAttendeeRepo ConfAttendee { get; private set; }

        public IUserRepo User { get; private set; }

        public ISpeakersRepo Speakers { get; private set; }

        public ISessionsRepo Sessions { get; private set; }

        public ITagsRepo Tags { get; private set; }

        public ISSpeakerRepo SSpeaker { get; private set; }

        public ISTagRepo STag { get; private set; }

        public ISAttendeeRepo SAttendee { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
