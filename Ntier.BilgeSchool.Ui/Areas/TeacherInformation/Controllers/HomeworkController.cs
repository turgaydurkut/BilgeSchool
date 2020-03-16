using Ntier.BilgeSchool.Model.Entity;
using Ntier.BilgeSchool.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ntier.BilgeSchool.Ui.Areas.TeacherInformation.Controllers
{
    [Authorize]
    public class HomeworkController : Controller
    {
        HomeworkService homeworkService = new HomeworkService();
        StudentService studentService = new StudentService();
        CourseService courseService = new CourseService();
        // GET: TeacherInformation/Homework
        public ActionResult Index()
        {
            return View(homeworkService.GetActive());
        }

        // GET: TeacherInformation/Homework/Details/5
        public ActionResult Details(int id)
        {
            return View(homeworkService.GetById(id));
        }

        // GET: TeacherInformation/Homework/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(studentService.GetActive(), "ID", "StudentName");
            ViewBag.CourseId = new SelectList(courseService.GetActive(), "ID", "CourseName");
            return View();
        }

        // POST: TeacherInformation/Homework/Create
        [HttpPost]
        public ActionResult Create(Homework homework)
        {
            try
            {
                ViewBag.StudentId = new SelectList(studentService.GetActive(), "ID", "StudentName");
                ViewBag.CourseId = new SelectList(courseService.GetActive(), "ID", "CourseName");
               
                homeworkService.Add(homework);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                TempData["Error"] = e.Message;
                return View();
            }
        }

        // GET: TeacherInformation/Homework/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.StudentId = new SelectList(studentService.GetActive(), "ID", "StudentName");
            ViewBag.CourseId = new SelectList(courseService.GetActive(), "ID", "CourseName");
            return View(homeworkService.GetById(id));
        }

        // POST: TeacherInformation/Homework/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Homework homework)
        {
            try
            {

                homeworkService.Update(homework);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherInformation/Homework/Delete/5
        public ActionResult Delete(int id)
        {
            return View(homeworkService.GetById(id));
        }

        // POST: TeacherInformation/Homework/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Homework homework)
        {
            try
            {

                homeworkService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
