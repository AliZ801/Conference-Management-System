using CMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.DataAccess.Data.IRepository
{
    public interface ITagsRepo : IRepository<Tags>
    {
        IEnumerable<SelectListItem> GetDropDownListForTags();

        void Update(Tags tags);
    }
}
