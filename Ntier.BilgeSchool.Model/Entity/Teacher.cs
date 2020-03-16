using Ntier.BilgeSchool.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntier.BilgeSchool.Model.Entity
{
   public class Teacher:CoreEntity//Öğretmenler
    {
        public Teacher()
        {
            this.Classrooms = new List<Classroom>();
            this.Sections = new List<Section>();
            this.Attendances = new List<Attendance>();
            this.Messages = new List<Message>();
            this.EducationSchedules = new List<EducationSchedule>();
        }
        public string TeacherName { get; set; }
        public string TeacherLastName { get; set; }
        public string DutyName { get; set; }
        public long TCKN { get; set; }
        public virtual int? BranchId { get; set; }
        public virtual int? CourseId { get; set; }
        


        public virtual Course Course { get; set; }
        public virtual Branch Branch { get; set; }
        

        public virtual List<Classroom> Classrooms { get; set; }
        public virtual List<Section> Sections { get; set; }
        public virtual List<Attendance> Attendances { get; set; } 
        public virtual List<Message> Messages { get; set; } 
        public virtual List<EducationSchedule> EducationSchedules { get; set; }
    }
}
