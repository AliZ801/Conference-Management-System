using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CMS.DataAccess.Data.IRepository;
using CMS.Utility;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class User : Controller
    {
        private readonly IUnitofWork _unitofWork;

        public User(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            return View(_unitofWork.User.GetAll(i => i.Id != claims.Value));
        }

        public IActionResult Lock(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _unitofWork.User.LockUser(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UnLock(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _unitofWork.User.UnLockUser(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
