using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.DataAccess.Data.IRepository;
using CMS.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Attendees : Controller
    {
        private readonly IUnitofWork _unitofWork;

        [BindProperty]
        public CMSViewModel CMSVM { get; set; }

        public Attendees(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddAttendee(int? id)
        {
            CMSVM = new CMSViewModel() { Attendees = new Models.Attendees() };

            if(id != null)
            {
                CMSVM.Attendees = _unitofWork.Attendees.Get(id.GetValueOrDefault());
            }

            return View(CMSVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAttendee()
        {
            if (ModelState.IsValid)
            {
                if(CMSVM.Attendees.Id == 0)
                {
                    _unitofWork.Attendees.Add(CMSVM.Attendees);
                }
                else
                {
                    _unitofWork.Attendees.Update(CMSVM.Attendees);
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
            return Json(new { data = _unitofWork.Attendees.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var aFromDb = _unitofWork.Attendees.Get(id);

            if(aFromDb == null)
            {
                return Json(new { success = false, message = "Error Deleting Attendee!" });
            }

            _unitofWork.Attendees.Remove(aFromDb);
            _unitofWork.Save();

            return Json(new { success = true, message = "Attendee Deleted Successfully!" });
        }

        #endregion
    }
}
