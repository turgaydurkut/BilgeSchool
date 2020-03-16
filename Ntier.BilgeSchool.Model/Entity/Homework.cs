using Ntier.BilgeSchool.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntier.BilgeSchool.Model.Entity
{
    public class Homework:CoreEntity//Ödev
    {
        
        public string Subject { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }

        [DataType("datetime2")]
        public DateTime DeadLine { get; set; }

        public int? CourseId { get; set; }
        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }

        
    }
}
