using Ntier.BilgeSchool.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntier.BilgeSchool.Model.Entity
{
   public class Course:CoreEntity
    {
        public Course()
        {
            this.CourseCodes = new List<CourseCode>();
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
            this.Sections = new List<Section>();
            this.Classrooms = new List<Classroom>();
            this.Homeworks = new List<Homework>();
            this.Attendances = new List<Attendance>();

        }

        [Required(ErrorMessage = "Lütfen Ders adınızı yazın")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Lütfen Ders Saatini  yazın")]
        public int CourseHour { get; set; }


        public int? PeriodId { get; set; }
        public int? EducationYearId { get; set; }


        public virtual Period Period { get; set; }
        public virtual EducationYear EducationYear { get; set; }



        public virtual List<CourseCode> CourseCodes { get; set; }
        public virtual List<Teacher> Teachers { get; set; }
        public virtual List<Student> Students { get; set; }
        public virtual List<Section> Sections { get; set; }
        public virtual List<Classroom> Classrooms { get; set; }
        public virtual List<Homework> Homeworks { get; set; }
        public virtual List<Attendance> Attendances { get; set; }


    }
}
