using Ntier.BilgeSchool.Model.Entity;
using Ntier.BilgeSchool.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ntier.BilgeSchool.Ui.Areas.Admin.Controllers
{
    [Authorize]
    public class EducationYearController : Controller
    {
        EducationYearService educationYearService = new EducationYearService();
        // GET: Admin/EducationYear
        public ActionResult Index()
        {
            var educationYears=educationYearService.GetActive();
            return View(educationYears);
        }

        // GET: Admin/EducationYear/Details/5
        public ActionResult Details(int id)
        {
            var educationYearDetail = educationYearService.GetById(id);
            return View(educationYearDetail);
        }

        // GET: Admin/EducationYear/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/EducationYear/Create
        [HttpPost]
        public ActionResult Create(EducationYear educationYear)
        {
            try
            {

                educationYearService.Add(educationYear);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/EducationYear/Edit/5
        public ActionResult Edit(int id)
        {
            var editEducationYear=educationYearService.GetById(id);
            return View(editEducationYear);
        }

        // POST: Admin/EducationYear/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EducationYear educationYear)
        {
            try
            {

                educationYearService.Update(educationYear);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/EducationYear/Delete/5
        public ActionResult Delete(int id)
        {
            var deletedEducationYear = educationYearService.GetById(id);
            return View(deletedEducationYear);
        }

        // POST: Admin/EducationYear/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EducationYear educationYear)
        {
            try
            {
                educationYearService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
