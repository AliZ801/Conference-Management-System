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
    public class Tracks : Controller
    {
        private readonly IUnitofWork _unitofWork;

        [BindProperty]
        public CMSViewModel CMSVM { get; set; }

        public Tracks(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddTrack(int? id)
        {
            CMSVM = new CMSViewModel() { Tracks = new Models.Tracks(), ConferenceList = _unitofWork.Conference.GetDropDownListForConference() };

            if (id != null)
            {
                CMSVM.Tracks = _unitofWork.Tracks.Get(id.GetValueOrDefault());
            }

            return View(CMSVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTrack()
        {
            if (ModelState.IsValid)
            {
                if (CMSVM.Tracks.Id == 0)
                {
                    _unitofWork.Tracks.Add(CMSVM.Tracks);
                }
                else
                {
                    _unitofWork.Tracks.Update(CMSVM.Tracks);
                }

                _unitofWork.Save();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                CMSVM.ConferenceList = _unitofWork.Conference.GetDropDownListForConference();

                return View(CMSVM);
            }
        }

        #region API CALLS

        public IActionResult GetAll()
        {
            return Json(new { data = _unitofWork.Tracks.GetAll(includeProperties: "Conference") });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var tFromDb = _unitofWork.Tracks.Get(id);

            if (tFromDb == null)
            {
                return Json(new { success = false, message = "Error Deleting Track!" });
            }

            _unitofWork.Tracks.Remove(tFromDb);
            _unitofWork.Save();

            return Json(new { success = true, message = "Track Deleted Successfully!" });
        }

        #endregion
    }
}
