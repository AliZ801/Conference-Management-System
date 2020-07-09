using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.DataAccess.Data.IRepository;
using CMS.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace CMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class Speakers : Controller
    {
        private readonly IUnitofWork _unitofWork;

        [BindProperty]
        public CMSViewModel CMSVM { get; set; }

        public Speakers(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddSpeaker(int? id)
        {
            CMSVM = new CMSViewModel()
            {
                Speakers = new Models.Speakers(),
                ConferenceList = _unitofWork.Conference.GetDropDownListForConference()
            };

            if(id != null)
            {
                CMSVM.Speakers = _unitofWork.Speakers.Get(id.GetValueOrDefault());
            }

            return View(CMSVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSpeaker()
        {
            if (ModelState.IsValid)
            {
                if (CMSVM.Speakers.Id == 0)
                {
                    _unitofWork.Speakers.Add(CMSVM.Speakers);
                }
                else
                {
                    _unitofWork.Speakers.Update(CMSVM.Speakers);
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
            return Json(new { data = _unitofWork.Speakers.GetAll(includeProperties: "Conference") });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var sFromDb = _unitofWork.Speakers.Get(id);

            if(sFromDb == null)
            {
                return Json(new { success = false, message = "Error Deleting Speaker!" });
            }

            _unitofWork.Speakers.Remove(sFromDb);
            _unitofWork.Save();

            return Json(new { success = true, message = "Speaker Deleted Successfully!" });
        }

        #endregion
    }
}
