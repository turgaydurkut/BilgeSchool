using Ntier.BilgeSchool.Model.Entity;
using Ntier.BilgeSchool.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ntier.BilgeSchool.Ui.Areas.Admin.Controllers
{
    public class GetStudentToSectionController : Controller
    {
        StudentService studentService = new StudentService();
        SectionService sectionService = new SectionService();
        ClassroomService classroomService = new ClassroomService();
        public ActionResult GetStudentSection(int id)
        {
            ViewBag.SectionId = new SelectList(sectionService.GetActive(), "ID", "SectionName");
            ViewBag.ClassroomId = new SelectList(classroomService.GetActive(), "ID", "ClassroomName");
            return View(studentService.GetById(id));
        }
        [HttpPost]
        public ActionResult GetStudentSection(Student student)
        {
            studentService.Update(student);
            return RedirectToAction("GetStudentIndex");
        }
        public ActionResult GetStudentIndex()
        {
            var student = studentService.GetActive().Where(x => x.ClassroomId != null && x.SectionId != null);
            return View(student);
        }
        public ActionResult StudentWaitSectionIndex()
        {
            var waitedstudent = studentService.GetActive().Where(x => x.SectionId == null && x.ClassroomId == null);
            return View(waitedstudent);
        }
        public ActionResult StudentDelete(int id)
        {
            return View(studentService.GetById(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, Student student)
        {
            try
            {
                studentService.Remove(id);
                return RedirectToAction("GetStudentIndex");
            }
            catch
            {
                return View();
            }
            
        }
    }
}