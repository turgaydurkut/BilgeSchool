using Ntier.BilgeSchool.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntier.BilgeSchool.Model.Entity
{
    public class Period : CoreEntity//Dönemler
    {
        public Period()
        {
            
            this.Courses = new List<Course>();
        }

        [Required(ErrorMessage = "Lütfen Dönem Adınızı yazın")]
        [Display(Name = "Dönem Adı")]
        public string PeriodName { get; set; }

        [Required(ErrorMessage = "Lütfen Başlangıç Tarihinizi yazın")]
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime StartedPeriod { get; set; }

        [Required(ErrorMessage = "Lütfen Bitiş Tarihinizi yazın")]
        [Display(Name = "Bitiş Tarihi")]
        public DateTime FinishedPeriod { get; set; }

        public int? EducationYearId { get; set; }


        public virtual EducationYear EducationYear { get; set; }


       
        public virtual List<Course> Courses { get; set; }
        public virtual List<Attendance> Attendances { get; set; }


    }
}
