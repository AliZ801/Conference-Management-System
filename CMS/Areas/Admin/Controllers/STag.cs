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
    public class STag : Controller
    {
        private readonly IUnitofWork _unitofWork;

        [BindProperty]
        public CMSViewModel CMSVM { get; set; }

        public STag(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddSTag(int? id)
        {
            CMSVM = new CMSViewModel()
            {
                STag = new Models.STag(),
                SessionsList = _unitofWork.Sessions.GetDropDownListForSessions(),
                TagsList = _unitofWork.Tags.GetDropDownListForTags()
            };

            if(id != null)
            {
                CMSVM.STag = _unitofWork.STag.Get(id.GetValueOrDefault());
            }

            return View(CMSVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSTag()
        {
            if (ModelState.IsValid)
            {
                if(CMSVM.STag.Id == 0)
                {
                    _unitofWork.STag.Add(CMSVM.STag);
                }
                else
                {
                    _unitofWork.STag.Update(CMSVM.STag);
                }

                _unitofWork.Save();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                CMSVM.SessionsList = _unitofWork.Sessions.GetDropDownListForSessions();
                CMSVM.TagsList = _unitofWork.Tags.GetDropDownListForTags();

                return View(CMSVM);
            }
        }

        #region API CALLS

        public IActionResult GetAll()
        {
            return Json(new { data = _unitofWork.STag.GetAll(includeProperties: "Sessions,Tags") });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var sTFromDb = _unitofWork.STag.Get(id);

            if(sTFromDb == null)
            {
                return Json(new { success = false, message = "Error Deleting Session Tag!" });
            }

            _unitofWork.STag.Remove(sTFromDb);
            _unitofWork.Save();

            return Json(new { success = true, message = "Session Tag Deleted Successfully!" });
        }

        #endregion
    }
}
