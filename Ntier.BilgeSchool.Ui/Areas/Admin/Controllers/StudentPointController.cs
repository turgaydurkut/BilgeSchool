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
    public class StudentPointController : Controller
    {
        
        CourseNoteService courseNoteService = new CourseNoteService();
        StudentService studentService = new StudentService();
        // GET: Admin/StudentPoint
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult GetStudentPoint()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult GetStudentPoint(Student student)
        {
            var courseNot = courseNoteService.GetAll().Where(x => x.Student.StudentNumber == student.StudentNumber);
            Session["Notes"] = courseNot;
            return RedirectToAction("Index");
        }
        string name;
        string lastName;
        string number;
        string dönem;
        public void ExportToExcel()
        {
            var Notlar=Session["Notes"];
            foreach (var item in Notlar as IEnumerable<CourseNote>)
            {
                name = item.Student.StudentName;
                lastName = item.Student.StudentLastName;
                number = item.Student.StudentNumber;
                dönem = item.Period.PeriodName;
            }
            ExcelPackage excelPackage = new ExcelPackage();
            ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("Notlar");
            excelWorksheet.Cells["A3"].Value = "Öğrenci Numarası";
            excelWorksheet.Cells["B3"].Value = number;
            excelWorksheet.Cells["A4"].Value = "Ad";
            excelWorksheet.Cells["B4"].Value = name;
            excelWorksheet.Cells["A5"].Value = "SoyAd";
            excelWorksheet.Cells["B5"].Value = lastName;
            excelWorksheet.Cells["A6"].Value = "Dönem";
            excelWorksheet.Cells["B6"].Value = dönem;

            excelWorksheet.Cells["A8"].Value = "Ders";
            excelWorksheet.Cells["B8"].Value = "Not";



            if (Notlar!=null)
            {
                int rowStart = 9;
                foreach (var item in Notlar as IEnumerable<CourseNote>)
                {
                    
                    excelWorksheet.Cells[string.Format("A{0}", rowStart)].Value = item.Course.CourseName;
                    excelWorksheet.Cells[string.Format("B{0}", rowStart)].Value = item.TotalPoint;
                    rowStart++;
                }
            }
            
            excelWorksheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment:filename" + "ExcelReport.xlsx");
            Response.BinaryWrite(excelPackage.GetAsByteArray());
            Response.End();


        }
    }
}