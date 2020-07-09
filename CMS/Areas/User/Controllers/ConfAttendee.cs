using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.DataAccess.Data.IRepository;
using CMS.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class ConfAttendee : Controller
    {
        private readonly IUnitofWork _unitofWork;

        [BindProperty]
        public EmployeeViewModel EVM { get; set; }

        public ConfAttendee(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            EVM = new EmployeeViewModel() { ConfAttendees = _unitofWork.ConfAttendee.GetAll(includeProperties: "Conference,Attendees") };

            return View(EVM);
        }

        public IActionResult CList()
        {
            EVM = new EmployeeViewModel() { Conference = _unitofWork.Conference.GetAll() };

            return View(EVM);
        }

        public IActionResult TrList()
        {
            EVM = new EmployeeViewModel() { Tracks = _unitofWork.Tracks.GetAll(includeProperties: "Conference") };

            return View(EVM);
        }

        public IActionResult SpList()
        {
            EVM = new EmployeeViewModel() { Speakers = _unitofWork.Speakers.GetAll() };

            return View(EVM);
        }

        public IActionResult SList()
        {
            EVM = new EmployeeViewModel() { Sessions = _unitofWork.Sessions.GetAll(includeProperties: "Conference,Tracks") };

            return View(EVM);
        }

        public IActionResult SSpList()
        {
            EVM = new EmployeeViewModel() { SSpeakers = _unitofWork.SSpeaker.GetAll(includeProperties: "Sessions,Speakers") };

            return View(EVM);
        }

        public IActionResult TList()
        {
            EVM = new EmployeeViewModel() { Tags = _unitofWork.Tags.GetAll() };

            return View(EVM);
        }

        public IActionResult STList()
        {
            EVM = new EmployeeViewModel() { STag = _unitofWork.STag.GetAll(includeProperties: "Sessions,Tags") };

            return View(EVM);
        }

        public IActionResult AList()
        {
            EVM = new EmployeeViewModel() { Attendees = _unitofWork.Attendees.GetAll() };

            return View(EVM);
        }

        public IActionResult SAList()
        {
            EVM = new EmployeeViewModel() { SAttendees = _unitofWork.SAttendee.GetAll(includeProperties: "Sessions,Attendees") };

            return View(EVM);
        }

        #region API CALLS

        public IActionResult GetAllCA()
        {
            return Json(new { data = _unitofWork.ConfAttendee.GetAll(includeProperties: "Conference,Attendees") });
        }

        public IActionResult GetAllC()
        {
            return Json(new { data = _unitofWork.Conference.GetAll() });
        }

        public IActionResult GetAllTr()
        {
            return Json(new { data = _unitofWork.Tracks.GetAll(includeProperties: "Conference") });
        }

        public IActionResult GetAllSp()
        {
            return Json(new { data = _unitofWork.Speakers.GetAll(includeProperties: "Conference") });
        }

        public IActionResult GetAllS()
        {
            return Json(new { data = _unitofWork.Sessions.GetAll(includeProperties: "Conference,Tracks") });
        }

        public IActionResult GetAllT()
        {
            return Json(new { data = _unitofWork.Tags.GetAll() });
        }

        public IActionResult GetAllSSp()
        {
            return Json(new { data = _unitofWork.SSpeaker.GetAll(includeProperties: "Sessions,Speakers") });
        }

        public IActionResult GetAllST()
        {
            return Json(new { data = _unitofWork.STag.GetAll(includeProperties: "Sessions,Tags") });
        }

        public IActionResult GetAllA()
        {
            return Json(new { data = _unitofWork.Attendees.GetAll() });
        }

        public IActionResult GetAllSA()
        {
            return Json(new { data = _unitofWork.SAttendee.GetAll(includeProperties: "Sessions,Attendees") });
        }

        #endregion
    }
}
