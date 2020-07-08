using CMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.DataAccess.Data.IRepository
{
    public interface IUserRepo : IRepository<ApplicationUser>
    {
        void LockUser(string UserId);

        void UnLockUser(string UserId);
    }
}
