using CMS.DataAccess.Data.IRepository;
using CMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.DataAccess.Data.Repository
{
    public class ConferenceRepo : Repository<Conference>, IConferenceRepo
    {
        private readonly ApplicationDbContext _db;

        public ConferenceRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetDropDownListForConference()
        {
            return _db.Conference.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(Conference conference)
        {
            var cFromDb = _db.Conference.FirstOrDefault(i => i.Id == conference.Id);

            cFromDb.Name = conference.Name;

            _db.SaveChanges();
        }
    }
}
