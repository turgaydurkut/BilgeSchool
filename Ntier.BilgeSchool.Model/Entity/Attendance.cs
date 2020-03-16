using Ntier.BilgeSchool.Core.Entity;
using Ntier.BilgeSchool.Model.Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntier.BilgeSchool.Model.Entity
{
   public class Attendance:CoreEntity//Yoklama
    {
        
        public AttendanceEvent Events { get; set; }
        public DateTime? Date { get; set; }
        public int? Gun { get; set; }
        public int? TotalDay 
        {
            get
            {
                return Gun++;
            }
            
        }

        public virtual int? EducationYearId { get; set; }
        public virtual int? StudentId { get; set; }
        public virtual int? CourseId { get; set; }
        public virtual int? PeriodId { get; set; }


        public virtual EducationYear EducationYear { get; set; }
        public virtual Student Student { get; set;}
        public virtual Course Course  { get; set;}
        public virtual Period Period { get; set;}
       

    }
}
