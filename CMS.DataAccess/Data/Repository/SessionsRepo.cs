using CMS.DataAccess.Data.IRepository;
using CMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.DataAccess.Data.Repository
{
    public class SessionsRepo : Repository<Sessions>, ISessionsRepo
    {
        private readonly ApplicationDbContext _db;

        public SessionsRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetDropDownListForSessions()
        {
            return _db.Sessions.Select(i => new SelectListItem()
            {
                Text = i.Title,
                Value = i.Id.ToString()
            });
        }

        public void Update(Sessions sessions)
        {
            var sFromDb = _db.Sessions.FirstOrDefault(i => i.Id == sessions.Id);

            sFromDb.Title = sessions.Title;
            sFromDb.STime = sessions.STime;
            sFromDb.ETime = sessions.ETime;
            sFromDb.ConferenceId = sessions.ConferenceId;
            sFromDb.TrackId = sessions.TrackId;

            _db.SaveChanges();
        }
    }
}
