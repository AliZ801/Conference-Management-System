﻿using CMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.DataAccess.Data.IRepository
{
    public interface ISpeakersRepo : IRepository<Speakers>
    {
        IEnumerable<SelectListItem> GetDropDownListForSpeakers();

        void Update(Speakers speakers);
    }
}
