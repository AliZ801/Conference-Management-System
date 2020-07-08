using CMS.DataAccess.Data.IRepository;
using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.DataAccess.Data.Repository
{
    public class UserRepo: Repository<ApplicationUser>, IUserRepo
    {
        private readonly ApplicationDbContext _db;

        public UserRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void LockUser(string UserId)
        {
            var uFromDb = _db.ApplicationUser.FirstOrDefault(i => i.Id == UserId);
            uFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            _db.SaveChanges();
        }

        public void UnLockUser(string UserId)
        {
            var uFromDb = _db.ApplicationUser.FirstOrDefault(i => i.Id == UserId);
            uFromDb.LockoutEnd = DateTime.Now;
            _db.SaveChanges();
        }
    }
}
