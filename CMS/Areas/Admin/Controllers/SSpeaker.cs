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
    public class SSpeaker : Controller
    {
        private readonly IUnitofWork _unitofWork;

        [BindProperty]
        public CMSViewModel CMSVM { get; set; }

        public SSpeaker(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddSSpeaker(int? id)
        {
            CMSVM = new CMSViewModel()
            {
                SSpeaker = new Models.SSpeaker(),
                SessionsList = _unitofWork.Sessions.GetDropDownListForSessions(),
                SpeakersList = _unitofWork.Speakers.GetDropDownListForSpeakers()
            };

            if(id != null)
            {
                CMSVM.SSpeaker = _unitofWork.SSpeaker.Get(id.GetValueOrDefault());
            }

            return View(CMSVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSSpeaker()
        {
            if (ModelState.IsValid)
            {
                if(CMSVM.SSpeaker.Id == 0)
                {
                    _unitofWork.SSpeaker.Add(CMSVM.SSpeaker);
                }
                else
                {
                    _unitofWork.SSpeaker.Update(CMSVM.SSpeaker);
                }

                _unitofWork.Save();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                CMSVM.SessionsList = _unitofWork.Sessions.GetDropDownListForSessions();
                CMSVM.SpeakersList = _unitofWork.Speakers.GetDropDownListForSpeakers();

                return View(CMSVM);
            }
        }

        #region API CALLS

        public IActionResult GetAll()
        {
            return Json(new { data = _unitofWork.SSpeaker.GetAll(includeProperties: "Sessions,Speakers") });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var sSFromDb = _unitofWork.SSpeaker.Get(id);

            if(sSFromDb == null)
            {
                return Json(new { success = false, message = "Error Deleting Session Speaker!" });
            }

            _unitofWork.SSpeaker.Remove(sSFromDb);
            _unitofWork.Save();

            return Json(new { success = true, message = "Session Speaker Deleted Successfully!" });
        }

        #endregion
    }
}
