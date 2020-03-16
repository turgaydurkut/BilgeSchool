using Ntier.BilgeSchool.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntier.BilgeSchool.Model.Entity
{
   public class CourseNote:CoreEntity
    {
        public decimal? PointOne { get; set; }
        public decimal? PointTwo { get; set; }
        public decimal? PointThree { get; set; }
        public decimal? HomeWorkNote { get; set; }
        public decimal? AveragePoint { get; set; }
        public int? TotalPoint { get; set; }


        public int? StudentId { get; set; }
        public int? PeriodId { get; set; }
        public int? EducationYearId { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Period Period { get; set; }
        public virtual EducationYear EducationYear { get; set; }
        public virtual Course Course { get; set; }

    }
}
