using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.DataAccess.Data.IRepository;
using CMS.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class Conference : Controller
    {
        private readonly IUnitofWork _unitofWork;

        [BindProperty]
        public CMSViewModel CMSVM { get; set; }

        public Conference(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddConference(int? id)
        {
            CMSVM = new CMSViewModel() { Conference = new Models.Conference() };

            if(id != null)
            {
                CMSVM.Conference = _unitofWork.Conference.Get(id.GetValueOrDefault());
            }

            return View(CMSVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddConference()
        {
            if (ModelState.IsValid)
            {
                if(CMSVM.Conference.Id == 0)
                {
                    _unitofWork.Conference.Add(CMSVM.Conference);
                }
                else
                {
                    _unitofWork.Conference.Update(CMSVM.Conference);
                }

                _unitofWork.Save();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(CMSVM);
            }
        }

        #region API CALLS

        public IActionResult GetAll()
        {
            return Json(new { data = _unitofWork.Conference.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var cFromDb = _unitofWork.Conference.Get(id);

            if(cFromDb == null)
            {
                return Json(new { success = false, message = "Error Deleting Conference!" });
            }

            _unitofWork.Conference.Remove(cFromDb);
            _unitofWork.Save();

            return Json(new { success = true, message = "Conference Deleted Successfully!" });
        }

        #endregion
    }
}
