using Ntier.BilgeSchool.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntier.BilgeSchool.Model.Entity
{
    public class Section:CoreEntity//Şubeler
    {
        public Section()
        {
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
            this.Courses = new List<Course>();
        }
        public string SectionName { get; set; }
        public int? ClassroomId { get; set; }
        public virtual Classroom Classroom { get; set; }

        public virtual List<Student> Students { get; set; }
        public virtual List<Teacher> Teachers { get; set; }
        public virtual List<Course> Courses { get; set; }
    }
}
