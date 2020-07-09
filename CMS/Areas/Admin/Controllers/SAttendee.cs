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
    public class SAttendee : Controller
    {
        private readonly IUnitofWork _unitofWork;

        [BindProperty]
        public CMSViewModel CMSVM { get; set; }

        public SAttendee(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddSAttendee(int? id)
        {
            CMSVM = new CMSViewModel()
            {
                SAttendee = new Models.SAttendee(),
                SessionsList = _unitofWork.Sessions.GetDropDownListForSessions(),
                AttendeesList = _unitofWork.Attendees.GetDropDownListForAttendees()
            };

            if(id != null)
            {
                CMSVM.SAttendee = _unitofWork.SAttendee.Get(id.GetValueOrDefault());
            }

            return View(CMSVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSAttendee()
        {
            if (ModelState.IsValid)
            {
                if(CMSVM.SAttendee.Id == 0)
                {
                    _unitofWork.SAttendee.Add(CMSVM.SAttendee);
                }
                else
                {
                    _unitofWork.SAttendee.Update(CMSVM.SAttendee);
                }

                _unitofWork.Save();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                CMSVM.SessionsList = _unitofWork.Sessions.GetDropDownListForSessions();
                CMSVM.AttendeesList = _unitofWork.Attendees.GetDropDownListForAttendees();

                return View(CMSVM);
            }
        }

        #region API CALLS

        public IActionResult GetAll()
        {
            return Json(new { data = _unitofWork.SAttendee.GetAll(includeProperties: "Sessions,Attendees") });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var sAFromDb = _unitofWork.SAttendee.Get(id);

            if(sAFromDb == null)
            {
                return Json(new { success = false, message = "Error Deleting Session Attendee!" });
            }

            _unitofWork.SAttendee.Remove(sAFromDb);
            _unitofWork.Save();

            return Json(new { success = true, message = "Session Attendee Deleted Successfully!" });
        }

        #endregion
    }
}
