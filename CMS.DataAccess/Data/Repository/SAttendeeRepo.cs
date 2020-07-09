using CMS.DataAccess.Data.IRepository;
using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.DataAccess.Data.Repository
{
    public class SAttendeeRepo : Repository<SAttendee>, ISAttendeeRepo
    {
        private readonly ApplicationDbContext _db;

        public SAttendeeRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(SAttendee sAttendee)
        {
            var sAFromDb = _db.SessionAttendees.FirstOrDefault(i => i.Id == sAttendee.Id);

            sAFromDb.SessionId = sAttendee.SessionId;
            sAFromDb.AttendeeId = sAttendee.AttendeeId;

            _db.SaveChanges();
        }
    }
}
