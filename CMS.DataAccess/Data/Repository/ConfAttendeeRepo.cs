using CMS.DataAccess.Data.IRepository;
using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.DataAccess.Data.Repository
{
    public class ConfAttendeeRepo : Repository<ConfAttendees>, IConfAttendeeRepo
    {
        private readonly ApplicationDbContext _db;

        public ConfAttendeeRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ConfAttendees confAttendees)
        {
            var caFromDb = _db.ConferenceAttendees.FirstOrDefault(i => i.Id == confAttendees.Id);

            caFromDb.ConferenceId = confAttendees.ConferenceId;
            caFromDb.AttendeeId = confAttendees.AttendeeId;

            _db.SaveChanges();
        }
    }
}
