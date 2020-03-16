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
    public class AttendanceController : Controller
    {
        CourseNoteService courseNoteService = new CourseNoteService();
        StudentService studentService = new StudentService();
        CourseService courseService = new CourseService();
        PeriodService periodService = new PeriodService();
        EducationYearService educationYearService = new EducationYearService();
        AttendanceService attendanceService = new AttendanceService();
        // GET: Admin/Attendance
        public ActionResult Index()
        {
            
            return View(attendanceService.GetActive());
        }

        // GET: Admin/Attendance/Details/5
        public ActionResult Details(int id)
        {
            return View(attendanceService.GetById(id));
        }

        // GET: Admin/Attendance/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(studentService.GetActive(), "ID", "StudentName");
            ViewBag.CourseId = new SelectList(courseService.GetActive(), "ID", "CourseName");
            ViewBag.PeriodId = new SelectList(periodService.GetActive(), "ID", "PeriodName");
            ViewBag.EducationYearId = new SelectList(educationYearService.GetActive(), "ID", "EducationYearName");
            return View();
        }

        // POST: Admin/Attendance/Create
        [HttpPost]
        public ActionResult Create(Attendance attendance)
        {
            try
            {
               
                attendanceService.Add(attendance);
                Session["Total"] = attendance.TotalDay;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Attendance/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.StudentId = new SelectList(studentService.GetActive(), "ID", "StudentName");
            ViewBag.CourseId = new SelectList(courseService.GetActive(), "ID", "CourseName");
            ViewBag.PeriodId = new SelectList(periodService.GetActive(), "ID", "PeriodName");
            ViewBag.EducationYearId = new SelectList(educationYearService.GetActive(), "ID", "EducationYearName");
            return View(attendanceService.GetById(id));
        }

        // POST: Admin/Attendance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Attendance attendance)
        {
            try
            {

                attendanceService.Update(attendance);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Attendance/Delete/5
        public ActionResult Delete(int id)
        {
            return View(attendanceService.GetById(id));
        }

        // POST: Admin/Attendance/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                attendanceService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
