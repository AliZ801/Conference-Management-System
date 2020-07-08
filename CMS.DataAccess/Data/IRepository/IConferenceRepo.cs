using CMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.DataAccess.Data.IRepository
{
    public interface IConferenceRepo : IRepository<Conference>
    {
        IEnumerable<SelectListItem> GetDropDownListForConference();

        void Update(Conference conference);
    }
}
