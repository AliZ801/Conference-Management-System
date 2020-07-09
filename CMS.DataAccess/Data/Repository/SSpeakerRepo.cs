using CMS.DataAccess.Data.IRepository;
using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.DataAccess.Data.Repository
{
    public class SSpeakerRepo : Repository<SSpeaker>, ISSpeakerRepo
    {
        private readonly ApplicationDbContext _db;

        public SSpeakerRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(SSpeaker sSpeaker)
        {
            var sSFromDb = _db.SessionSpeaker.FirstOrDefault(i => i.Id == sSpeaker.Id);

            sSFromDb.SessionId = sSpeaker.SessionId;
            sSFromDb.SpeakerId = sSpeaker.SpeakerId;

            _db.SaveChanges();
        }
    }
}
