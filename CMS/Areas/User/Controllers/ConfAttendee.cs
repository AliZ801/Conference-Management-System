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
    }
}
