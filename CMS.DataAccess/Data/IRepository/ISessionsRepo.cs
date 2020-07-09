using CMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.DataAccess.Data.IRepository
{
    public interface ISessionsRepo : IRepository<Sessions>
    {
        IEnumerable<SelectListItem> GetDropDownListForSessions();

        void Update(Sessions sessions);
    }
}
