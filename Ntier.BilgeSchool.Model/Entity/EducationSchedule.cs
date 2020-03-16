using Ntier.BilgeSchool.Core.Entity;
using Ntier.BilgeSchool.Model.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntier.BilgeSchool.Model.Entity
{
    public class EducationSchedule : CoreEntity
    {
        public Day Day { get; set; }
        public string LessonOne { get; set; }
        public string LessonTwo { get; set; }
        public string LessonThree { get; set; }
        public string LessonFour { get; set; }
        public string LessonFive { get; set; }
        public string LessonSix { get; set; }
        public string LessonSeven { get; set; }
        public string LessonEigth { get; set; }

        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
    


}

