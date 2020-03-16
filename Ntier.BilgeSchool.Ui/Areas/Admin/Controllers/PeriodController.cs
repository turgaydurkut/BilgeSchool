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
    public class PeriodController : Controller
    {
        PeriodService periodService = new PeriodService();
        EducationYearService educationYearService = new EducationYearService();
        // GET: Admin/Period
        public ActionResult Index()
        {
            
            return View(periodService.GetActive());
        }

        // GET: Admin/Period/Details/5
        public ActionResult Details(int id)
        {
            
            return View(periodService.GetById(id));
        }

        // GET: Admin/Period/Create
        public ActionResult Create()
        {
            Period period = new Period();
            var educationYears=educationYearService.GetActive();
            ViewBag.EducationYearId = new SelectList(educationYears, "ID", "EducationYearName",period.EducationYearId);
            return View();
        }

        // POST: Admin/Period/Create
        [HttpPost]
        public ActionResult Create(Period period)
        {
            try
            {
                periodService.Add(period);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Period/Edit/5
        public ActionResult Edit(int id)
        {
            Period period = new Period();
            var educationYears = educationYearService.GetActive();
            ViewBag.EducationYearId = new SelectList(educationYears, "ID", "EducationYearName", period.EducationYearId);
            return View(periodService.GetById(id));
        }

        // POST: Admin/Period/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Period period)
        {
            try
            {

                periodService.Update(period);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Period/Delete/5
        public ActionResult Delete(int id)
        {
            return View(periodService.GetById(id));
        }

        // POST: Admin/Period/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                periodService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
