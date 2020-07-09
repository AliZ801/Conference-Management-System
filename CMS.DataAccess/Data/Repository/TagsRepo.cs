using CMS.DataAccess.Data.IRepository;
using CMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.DataAccess.Data.Repository
{
    public class TagsRepo : Repository<Tags>, ITagsRepo
    {
        private readonly ApplicationDbContext _db;

        public TagsRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetDropDownListForTags()
        {
            return _db.Tags.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(Tags tags)
        {
            var tFromDb = _db.Tags.FirstOrDefault(i => i.Id == tags.Id);

            tFromDb.Name = tags.Name;

            _db.SaveChanges();
        }
    }
}
