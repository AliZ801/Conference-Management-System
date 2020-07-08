using CMS.DataAccess.Data.IRepository;
using CMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.DataAccess.Data.Repository
{
    public class TracksRepo : Repository<Tracks>, ITracksRepo
    {
        private readonly ApplicationDbContext _db;

        public TracksRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetDropDownListForTracks()
        {
            return _db.Tracks.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(Tracks tracks)
        {
            var tFromDb = _db.Tracks.FirstOrDefault(i => i.Id == tracks.Id);

            tFromDb.Name = tracks.Name;
            tFromDb.ConferenceId = tracks.ConferenceId;

            _db.SaveChanges();
        }
    }
}
