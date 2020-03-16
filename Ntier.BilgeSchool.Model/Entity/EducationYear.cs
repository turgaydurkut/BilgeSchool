using Ntier.BilgeSchool.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntier.BilgeSchool.Model.Entity
{
    public class EducationYear:CoreEntity
    {
        public EducationYear()//Eğitim Öğretim Yılı
        {
            this.Periods = new List<Period>();
            this.Attendances = new List<Attendance>();
            this.Courses = new List<Course>();
        }

        [Required(ErrorMessage = "Lütfen Eğitim Öğretim Yılın yazın")]
        public string EducationYearName { get; set; }

        public virtual List<Period> Periods { get; set; }
        public virtual List<Attendance> Attendances { get; set; }
        public virtual List<Course> Courses { get; set; }




    }
}
