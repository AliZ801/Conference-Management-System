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
    public class Tags : Controller
    {
        private readonly IUnitofWork _unitofWork;

        [BindProperty]
        public CMSViewModel CMSVM { get; set; }

        public Tags(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddTag(int? id)
        {
            CMSVM = new CMSViewModel() { Tags = new Models.Tags() };

            if(id != null)
            {
                CMSVM.Tags = _unitofWork.Tags.Get(id.GetValueOrDefault());
            }

            return View(CMSVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTag()
        {
            if (ModelState.IsValid)
            {
                if(CMSVM.Tags.Id == 0)
                {
                    _unitofWork.Tags.Add(CMSVM.Tags);
                }
                else
                {
                    _unitofWork.Tags.Update(CMSVM.Tags);
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
            return Json(new { data = _unitofWork.Tags.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var tFromDb = _unitofWork.Tags.Get(id);

            if(tFromDb == null)
            {
                return Json(new { success = false, message = "Error Deleting Tag!" });
            }

            _unitofWork.Tags.Remove(tFromDb);
            _unitofWork.Save();

            return Json(new { success = true, message = "Tag Deleted Successfully!" });
        }

        #endregion
    }
}
