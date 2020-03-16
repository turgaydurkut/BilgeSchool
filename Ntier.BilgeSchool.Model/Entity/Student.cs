using Ntier.BilgeSchool.Core.Entity;
using Ntier.BilgeSchool.Model.Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntier.BilgeSchool.Model.Entity
{
    public class Student:CoreEntity//Öğrenciler
    {
        public Student()
        {
                this.Courses = new List<Course>();
                this.Messages = new List<Message>();
                this.CourseNotes = new List<CourseNote>();
                this.Attendances = new List<Attendance>();
                this.Homeworks = new List<Homework>();
           
        }

        [Required(ErrorMessage = "Lütfen Öğrenci Adını yazın")]
        [Display(Name = "Öğrenci Adı")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Lütfen Öğrenci SoyAdını yazın")]
        [Display(Name = "Öğrenci SoyAdı")]
        public string StudentLastName { get; set; }

        [Display(Name = "Öğrenci Numarası")]
        public string StudentNumber { get; set; }

        [Display(Name = "Cinsiyet")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Lütfen Mezun Olduğu Okulu yazın")]
        [Display(Name = "Mezun Olduğu Okul")]
        public string GraduatedSchool { get; set; }

        
        [Display(Name = "Mezuniyet Notu")]
        public decimal? AverageGrade { get; set; }

        
       
        public int? SectionId { get; set; }
        public int? ClassroomId { get; set; }
        public int? FamilyId { get; set; }

        

        public virtual Family Family { get; set; }
        public virtual Section Section { get; set; }
        public virtual Classroom Classroom { get; set; }
      


        public virtual List<Course> Courses { get; set; }
        public virtual List<Message> Messages { get; set; }
        public virtual List<Attendance> Attendances { get; set; }
        public virtual List<Homework> Homeworks { get; set; }
        public virtual List<CourseNote>  CourseNotes{ get; set; }
       
    }
}
