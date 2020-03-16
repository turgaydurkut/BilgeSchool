using Ntier.BilgeSchool.Model.Context;
using Ntier.BilgeSchool.Model.Entity;
using Ntier.BilgeSchool.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ntier.BilgeSchool.Ui.Areas.StudentInformation.Controllers
{
    [Authorize]
    public class StudentDataController : Controller
    {
        CourseNoteService courseNoteService = new CourseNoteService();
        AttendanceService attendanceService = new AttendanceService();
        HomeworkService homeworkService = new HomeworkService();
        public ActionResult Anasayfa()
        {
            return View();

        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CourseNotes()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CourseNotes(Student student)
        {
            var courseNotes = courseNoteService.GetActive().Where(x => x.Student.StudentNumber == student.StudentNumber);
            Session["Notes"] = courseNotes;
            return RedirectToAction("Index");

        }
        public ActionResult Attendances()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Attendances(Student student)
        {
            var attendances = attendanceService.GetActive().Where(x => x.Student.StudentNumber == student.StudentNumber);
            Session["Attendances"] = attendances;

            return RedirectToAction("IndexAttendances");
        }
        public ActionResult IndexAttendances()
        {
            return View();
        }
        public ActionResult Homework()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Homework(Student student)
        {
            var homework = homeworkService.GetActive().Where(x => x.Student.StudentNumber == student.StudentNumber);
            Session["Homework"] =homework;

            return RedirectToAction("IndexHomework");
        }
        public ActionResult IndexHomework()
        {
            return View();
        }
    }
}