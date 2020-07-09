using CMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.DataAccess.Data.IRepository
{
    public interface ISAttendeeRepo : IRepository<SAttendee>
    {
        void Update(SAttendee sAttendee);
    }
}
