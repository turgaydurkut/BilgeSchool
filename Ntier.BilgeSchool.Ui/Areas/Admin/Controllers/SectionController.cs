
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
    public class SectionController : Controller
    {
        ClassroomService classroomService = new ClassroomService();
        SectionService sectionService = new SectionService();
        // GET: Admin/Section
        public ActionResult Index()
        {
            return View(sectionService.GetActive());
        }

        // GET: Admin/Section/Details/5
        public ActionResult Details(int id)
        {
            return View(sectionService.GetById(id));
        }

        // GET: Admin/Section/Create
        public ActionResult Create()
        {
            ViewBag.ClassroomId = new SelectList(classroomService.GetActive(), "ID", "ClassroomName");
            return View();
        }

        // POST: Admin/Section/Create
        [HttpPost]
        public ActionResult Create(Section section)
        {
            try
            {
                sectionService.Add(section);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Section/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ClassroomId = new SelectList(classroomService.GetActive(), "ID", "ClassroomName");
            return View(sectionService.GetById(id));
        }

        // POST: Admin/Section/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Section section)
        {
            try
            {
                sectionService.Update(section);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Section/Delete/5
        public ActionResult Delete(int id)
        {
            return View(sectionService.GetById(id));
        }

        // POST: Admin/Section/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                sectionService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
