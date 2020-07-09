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
    public class ConfAttendees : Controller
    {
        private readonly IUnitofWork _unitofWork;

        [BindProperty]
        public CMSViewModel CMSVM { get; set; }

        public ConfAttendees(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddConfAttendee(int? id)
        {
            CMSVM = new CMSViewModel()
            {
                ConfAttendees = new Models.ConfAttendees(),
                ConferenceList = _unitofWork.Conference.GetDropDownListForConference(),
                AttendeesList = _unitofWork.Attendees.GetDropDownListForAttendees()
            };

            if(id != null)
            {
                CMSVM.ConfAttendees = _unitofWork.ConfAttendee.Get(id.GetValueOrDefault());
            }

            return View(CMSVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddConfAttendee()
        {
            if (ModelState.IsValid)
            {
                if(CMSVM.ConfAttendees.Id == 0)
                {
                    _unitofWork.ConfAttendee.Add(CMSVM.ConfAttendees);
                }
                else
                {
                    _unitofWork.ConfAttendee.Update(CMSVM.ConfAttendees);
                }

                _unitofWork.Save();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                CMSVM.ConferenceList = _unitofWork.Conference.GetDropDownListForConference();
                CMSVM.AttendeesList = _unitofWork.Attendees.GetDropDownListForAttendees();

                return View(CMSVM);
            }
        }

        #region API CALLS

        public IActionResult GetAll()
        {
            return Json(new { data = _unitofWork.ConfAttendee.GetAll(includeProperties: "Conference,Attendees") });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var caFromDb = _unitofWork.ConfAttendee.Get(id);

            if (caFromDb == null)
            {
                return Json(new { success = false, message = "Error Deleting Conference Attendee!" });
            }

            _unitofWork.ConfAttendee.Remove(caFromDb);
            _unitofWork.Save();

            return Json(new { success = true, message = "Conference Attendee Deleted Successfully!" });
        }

        #endregion
    }
}
