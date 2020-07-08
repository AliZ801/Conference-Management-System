using CMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.DataAccess.Data.IRepository
{
    public interface IAttendeesRepo : IRepository<Attendees>
    {
        IEnumerable<SelectListItem> GetDropDownListForAttendees();

        void Update(Attendees attendees);
    }
}
