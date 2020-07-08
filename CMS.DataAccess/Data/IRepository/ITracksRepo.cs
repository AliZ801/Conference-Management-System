using CMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.DataAccess.Data.IRepository
{
    public interface ITracksRepo : IRepository<Tracks>
    {
        IEnumerable<SelectListItem> GetDropDownListForTracks();

        void Update(Tracks tracks);
    }
}
