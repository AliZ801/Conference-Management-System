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
    public class Sessions : Controller
    {
        private readonly IUnitofWork _unitofWork;

        [BindProperty]
        public CMSViewModel CMSVM { get; set; }

        public Sessions(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddSession(int? id)
        {
            CMSVM = new CMSViewModel()
            {
                Sessions = new Models.Sessions(),
                ConferenceList = _unitofWork.Conference.GetDropDownListForConference(),
                TracksList = _unitofWork.Tracks.GetDropDownListForTracks()
            };

            if(id != null)
            {
                CMSVM.Sessions = _unitofWork.Sessions.Get(id.GetValueOrDefault());
            }

            return View(CMSVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSession()
        {
            if (ModelState.IsValid)
            {
                if(CMSVM.Sessions.Id == 0)
                {
                    _unitofWork.Sessions.Add(CMSVM.Sessions);
                }
                else
                {
                    _unitofWork.Sessions.Update(CMSVM.Sessions);
                }

                _unitofWork.Save();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                CMSVM.ConferenceList = _unitofWork.Conference.GetDropDownListForConference();
                CMSVM.TracksList = _unitofWork.Tracks.GetDropDownListForTracks();

                return View(CMSVM);
            }
        }

        public IActionResult Detail(int id)
        {
            var sFromDb = _unitofWork.Sessions.GetFirstOrDefault(includeProperties: "Conference,Tracks", filter: i => i.Id == id);

            return View(sFromDb);
        }

        #region API CALLS

        public IActionResult GetAll()
        {
            return Json(new { data = _unitofWork.Sessions.GetAll(includeProperties: "Conference,Tracks") });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var sFromDb = _unitofWork.Sessions.Get(id);

            if(sFromDb == null)
            {
                return Json(new { success = false, message = "Error Deleting Session!" });
            }

            _unitofWork.Sessions.Remove(sFromDb);
            _unitofWork.Save();

            return Json(new { success = true, message = "Session Deleted Successfully!" });
        }

        #endregion
    }
}
