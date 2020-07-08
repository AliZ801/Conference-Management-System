using CMS.DataAccess.Data.IRepository;
using CMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.DataAccess.Data.Repository
{
    public class AttendeesRepo : Repository<Attendees>, IAttendeesRepo
    {
        private readonly ApplicationDbContext _db;

        public AttendeesRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetDropDownListForAttendees()
        {
            return _db.Attendees.Select(i => new SelectListItem()
            {
                Text = i.FName,
                Value = i.Id.ToString()
            });
        }

        public void Update(Attendees attendees)
        {
            var aFromDb = _db.Attendees.FirstOrDefault(i => i.Id == attendees.Id);

            aFromDb.FName = attendees.FName;
            aFromDb.Email = attendees.Email;

            _db.SaveChanges();
        }
    }
}
