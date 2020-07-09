using CMS.DataAccess.Data.IRepository;
using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.DataAccess.Data.Repository
{
    public class STagRepo : Repository<STag>, ISTagRepo
    {
        private readonly ApplicationDbContext _db;

        public STagRepo(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(STag sTag)
        {
            var sTFromDb = _db.SessionTag.FirstOrDefault(i => i.Id == sTag.Id);

            sTFromDb.SessionId = sTag.SessionId;
            sTFromDb.TagId = sTag.TagId;

            _db.SaveChanges();
        }
    }
}
