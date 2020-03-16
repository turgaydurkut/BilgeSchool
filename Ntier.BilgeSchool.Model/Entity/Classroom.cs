using Ntier.BilgeSchool.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntier.BilgeSchool.Model.Entity
{
    public class Classroom:CoreEntity//Sınıflar
    {
        public Classroom()
        {
            this.Sections = new List<Section>();
            this.Teachers = new List<Teacher>();
            this.Students = new List<Student>();
            this.Courses = new List<Course>();
        }

        [Required(ErrorMessage = "Lütfen Sınıf adınızı yazın")]
        public string ClassroomName { get; set; }
        public virtual List<Section>  Sections { get; set; }
        public virtual List<Teacher>  Teachers { get; set; }
        public virtual List<Student> Students { get; set; }
        public virtual List<Course> Courses { get; set; }


        

    }
}
