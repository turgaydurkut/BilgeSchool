using Ntier.BilgeSchool.Model.Entity;
using Ntier.BilgeSchool.Service.Option;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ntier.BilgeSchool.Ui.Areas.Admin.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        PeriodService periodService = new PeriodService();
        EducationYearService educationYearService = new EducationYearService();
        CourseService courseService = new CourseService();
        // GET: Admin/Course
        public ActionResult Index()
        {
            var courseList=courseService.GetActive();
            return View(courseList);
        }

        public void ExportToExcel()
        {
            var courses = courseService.GetActive();
            ExcelPackage excelPackage = new ExcelPackage();
            ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("Notlar");

            excelWorksheet.Cells["A1"].Value = "ID";
            excelWorksheet.Cells["B1"].Value = "CourseName";
            excelWorksheet.Cells["C1"].Value = "CourseHour";
            excelWorksheet.Cells["D1"].Value = "Period";

            int rowStart = 2;
            foreach (var item in courses)
            {
                excelWorksheet.Cells[string.Format("A{0}", rowStart)].Value = item.ID;
                excelWorksheet.Cells[string.Format("B{0}", rowStart)].Value = item.CourseName;
                excelWorksheet.Cells[string.Format("C{0}", rowStart)].Value = item.CourseHour;
                excelWorksheet.Cells[string.Format("D{0}", rowStart)].Value = item.Period.PeriodName;
                rowStart++;
            }
            excelWorksheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment:filename" + "Ders.xlsx");
            Response.BinaryWrite(excelPackage.GetAsByteArray());
            Response.End();


        }

        // GET: Admin/Course/Details/5
        public ActionResult Details(int id)
        {
            var courseDetail=courseService.GetById(id);
            return View(courseDetail);
        }

        // GET: Admin/Course/Create
        public ActionResult Create()
        {
           
            ViewBag.PeriodId = new SelectList(periodService.GetActive(), "ID", "PeriodName");
            ViewBag.EducationYearId = new SelectList(educationYearService.GetActive(), "ID", "EducationYearName");
            return View();
        }

        // POST: Admin/Course/Create
        [HttpPost]
        public ActionResult Create(Course course)
        {
            try
            {

                courseService.Add(course);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Course/Edit/5
        public ActionResult Edit(int id)
        {

            ViewBag.PeriodId = new SelectList(periodService.GetActive(), "ID", "PeriodName");
            ViewBag.EducationYearId = new SelectList(educationYearService.GetActive(), "ID", "EducationYearName");
            var courseEdit = courseService.GetById(id);
            return View(courseEdit);
        }

        // POST: Admin/Course/Edit/5
        [HttpPost]
        public ActionResult Edit(Course course)
        {
            try
            {

                courseService.Update(course);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Course/Delete/5
        public ActionResult Delete(int id)
        {
            
            return View(courseService.GetById(id));
        }
        // POST: Admin/Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Course course)
        {
            try
            {

                courseService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
