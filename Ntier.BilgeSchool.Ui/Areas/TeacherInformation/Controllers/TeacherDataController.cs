using Ntier.BilgeSchool.Model.Context;
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
    public class TeacherDataController : Controller
    {
       
        TeacherService teacherService = new TeacherService();
        CourseNoteService courseNoteService = new CourseNoteService();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StudentNotes()
        {
            return View();
        }
        public ActionResult StudentNotes(Teacher teacher)
        {
            return View();
        }
    }
}