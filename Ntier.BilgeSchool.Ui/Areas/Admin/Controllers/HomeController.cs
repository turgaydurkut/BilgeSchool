using Ntier.BilgeSchool.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ntier.BilgeSchool.Ui.Areas.Admin.Controllers
{
    
    [Authorize]
    public class HomeController : Controller
    {
        StudentService studentService = new StudentService();
        TeacherService teacherService = new TeacherService();
        ClassroomService classroomService = new ClassroomService();
        SectionService sectionService = new SectionService();
        // GET: Admin/Home
        public ActionResult Index()
        {
            Session["Student"] = studentService.GetActive().Count().ToString();
            Session["Teacher"] = teacherService.GetActive().Count().ToString();
            Session["Classroom"] = classroomService.GetActive().Count().ToString();
            Session["Section"] = sectionService.GetActive().Count().ToString();
            return View();
        }
    }
}