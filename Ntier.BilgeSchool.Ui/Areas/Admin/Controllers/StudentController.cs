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
    public class StudentController : Controller
    {
        StudentService studentService = new StudentService();
        SectionService sectionService = new SectionService();
        ClassroomService classroomService = new ClassroomService();
        // GET: Admin/Student
        public ActionResult Index()
        {
            return View(studentService.GetActive());
        }

        // GET: Admin/Student/Details/5
        public ActionResult Details(int id)
        {
            return View(studentService.GetById(id));
        }
       
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            studentService.Add(student);
            student.StudentNumber = studentService.GetStudentNumber(student.ID);
            studentService.Update(student);
            return RedirectToAction("Index");
        }

        // GET: Admin/Student/Edit/5
        public ActionResult Edit(int id)
        {
            if (id!=0)
            {
                ViewBag.SectionId = new SelectList(sectionService.GetActive(), "ID", "SectionName");
                ViewBag.ClassroomId = new SelectList(classroomService.GetActive(), "ID", "ClassroomName");

                return View(studentService.GetById(id));
            }
            return View();
        }

        // POST: Admin/Student/Edit/5
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            try
            {
                studentService.Update(student);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View(studentService.GetById(id));
        }

        // POST: Admin/Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,Student student)
        {
            try
            {
                studentService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
       
    }
}
