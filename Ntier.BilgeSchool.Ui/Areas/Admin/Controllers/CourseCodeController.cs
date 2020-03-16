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
    public class CourseCodeController : Controller
    {
        CourseService courseService = new CourseService();
        CourseCodeService courseCodeService = new CourseCodeService();
        // GET: Admin/CourseCode
        public ActionResult Index()
        {
            ViewBag.CourseId = new SelectList(courseService.GetActive(), "ID", "CourseName");
            return View(courseCodeService.GetActive());
        }

        // GET: Admin/CourseCode/Details/5
        public ActionResult Details(int id)
        {
            return View(courseCodeService.GetById(id));
        }

        // GET: Admin/CourseCode/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(courseService.GetActive(), "ID", "CourseName");
            return View();
        }

        // POST: Admin/CourseCode/Create
        [HttpPost]
        public ActionResult Create(CourseCode courseCode)
        {
            try
            {

                courseCodeService.Add(courseCode);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/CourseCode/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CourseId = new SelectList(courseService.GetActive(), "ID", "CourseName");
            return View(courseCodeService.GetById(id));
        }

        // POST: Admin/CourseCode/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CourseCode courseCode)
        {
            try
            {

                courseCodeService.Update(courseCode);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/CourseCode/Delete/5
        public ActionResult Delete(int id)
        {
            return View(courseCodeService.GetById(id));
        }

        // POST: Admin/CourseCode/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                courseCodeService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
