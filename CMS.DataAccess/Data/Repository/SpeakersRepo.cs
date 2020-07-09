using CMS.DataAccess.Data.IRepository;
using CMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.DataAccess.Data.Repository
{
    public class SpeakersRepo : Repository<Speakers>, ISpeakersRepo
    {
        private readonly ApplicationDbContext _db;

        public SpeakersRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetDropDownListForSpeakers()
        {
            return _db.Speakers.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(Speakers speakers)
        {
            var sFromDb = _db.Speakers.FirstOrDefault(i => i.Id == speakers.Id);

            sFromDb.Name = speakers.Name;
            sFromDb.ConferenceId = speakers.ConferenceId;

            _db.SaveChanges();
        }
    }
}
