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
    public class ClassroomController : Controller
    {
        ClassroomService classroomService = new ClassroomService();
        // GET: Admin/Classroom
        public ActionResult Index()
        {
            return View(classroomService.GetActive());
        }

        // GET: Admin/Classroom/Details/5
        public ActionResult Details(int id)
        {
            return View(classroomService.GetById(id));
        }

        // GET: Admin/Classroom/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Classroom/Create
        [HttpPost]
        public ActionResult Create(Classroom classroom)
        {
            try
            {
                classroomService.Add(classroom);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Classroom/Edit/5
        public ActionResult Edit(int id)
        {
            return View(classroomService.GetById(id));
        }

        // POST: Admin/Classroom/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Classroom classroom)
        {
            try
            {

                classroomService.Update(classroom);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Classroom/Delete/5
        public ActionResult Delete(int id)
        {
            return View(classroomService.GetById(id));
        }

        // POST: Admin/Classroom/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Classroom classroom)
        {
            try
            {

                classroomService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
