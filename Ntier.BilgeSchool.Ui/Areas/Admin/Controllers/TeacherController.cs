using Ntier.BilgeSchool.Model.Context;
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
    public class TeacherController : Controller
    {
        
        
        TeacherService teacherService = new TeacherService();
        CourseService courseService = new CourseService();
        BranchService branchService = new BranchService();
        // GET: Admin/Teacher
        public ActionResult Index()
        {
            return View(teacherService.GetActive());
        }

        // GET: Admin/Teacher/Details/5
        public ActionResult Details(int id)
        {
            return View(teacherService.GetById(id));
        }

        // GET: Admin/Teacher/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(branchService.GetActive(), "ID", "BranchName");
            ViewBag.CourseId = new SelectList(courseService.GetActive(), "ID", "CourseName");
            return View();
        }

        // POST: Admin/Teacher/Create
        [HttpPost]
        public ActionResult Create(Teacher  teacher)
        {
            try
            {

                teacherService.Add(teacher);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Teacher/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.BranchId = new SelectList(branchService.GetActive(), "ID", "BranchName");
            ViewBag.CourseId = new SelectList(courseService.GetActive(), "ID", "CourseName");
            return View(teacherService.GetById(id));
        }

        // POST: Admin/Teacher/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Teacher teacher)
        {
            try
            {
                teacherService.Update(teacher);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Teacher/Delete/5
        public ActionResult Delete(int id)
        {
            return View(teacherService.GetById(id));
        }

        // POST: Admin/Teacher/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                teacherService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
