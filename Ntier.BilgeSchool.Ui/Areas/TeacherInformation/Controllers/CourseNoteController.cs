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
    public class CourseNoteController : Controller
    {
        CourseNoteService courseNoteService = new CourseNoteService();
        StudentService studentService = new StudentService();
        CourseService courseService = new CourseService();
        PeriodService periodService = new PeriodService();
        EducationYearService educationYearService = new EducationYearService();
        // GET: Admin/CourseNote
        public ActionResult Index()
        {
            return View(courseNoteService.GetActive());
        }

        // GET: Admin/CourseNote/Details/5
        public ActionResult Details(int id)
        {
            return View(courseNoteService.GetById(id));
        }

        // GET: Admin/CourseNote/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(studentService.GetActive(), "ID", "StudentName");
            ViewBag.CourseId = new SelectList(courseService.GetActive(), "ID", "CourseName");
            ViewBag.PeriodId = new SelectList(periodService.GetActive(), "ID", "PeriodName");
            ViewBag.EducationYearId = new SelectList(educationYearService.GetActive(), "ID", "EducationYearName");
            return View();
        }

        // POST: Admin/CourseNote/Create
        [HttpPost]
        public ActionResult Create(CourseNote courseNote)
        {
            try
            {
                if (courseNote.HomeWorkNote == null)
                {
                    courseNote.AveragePoint = (courseNote.PointOne + courseNote.PointTwo + courseNote.PointThree) / 3;
                }
                else 
                {
                    courseNote.AveragePoint = (courseNote.PointOne + courseNote.PointTwo + courseNote.PointThree+courseNote.HomeWorkNote) / 4;
                }
                var note = courseNote.AveragePoint;
                courseNote.TotalPoint =Convert.ToInt32(courseNoteService.GetTotalPoint(note));
                courseNoteService.Add(courseNote);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/CourseNote/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.StudentId = new SelectList(studentService.GetActive(), "ID", "StudentName");
            ViewBag.CourseId = new SelectList(courseService.GetActive(), "ID", "CourseName");
            ViewBag.PeriodId = new SelectList(periodService.GetActive(), "ID", "PeriodName");
            ViewBag.EducationYearId = new SelectList(educationYearService.GetActive(), "ID", "EducationYearName");
            return View(courseNoteService.GetById(id));
        }

        // POST: Admin/CourseNote/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CourseNote courseNote)
        {
            try
            {
                if (courseNote.HomeWorkNote == null)
                {
                    courseNote.AveragePoint = (courseNote.PointOne + courseNote.PointTwo + courseNote.PointThree) / 3;
                }
                else
                {
                    courseNote.AveragePoint = (courseNote.PointOne + courseNote.PointTwo + courseNote.PointThree + courseNote.HomeWorkNote) / 4;
                }
                var note = courseNote.AveragePoint;
                courseNote.TotalPoint = Convert.ToInt32(courseNoteService.GetTotalPoint(note));
                courseNoteService.Update(courseNote);
                return RedirectToAction("Index");

                
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/CourseNote/Delete/5
        public ActionResult Delete(int id)
        {
            return View(courseNoteService.GetById(id));
        }

        // POST: Admin/CourseNote/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CourseNote courseNote)
        {
            try
            {

                courseNoteService.Remove(courseNote);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
