using Ntier.BilgeSchool.Model.Entity;
using Ntier.BilgeSchool.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntier.BilgeSchool.Service.Option
{
    public class CourseNoteService:BaseService<CourseNote>
    {
        public decimal GetTotalPoint(decimal? item)
        {
            if (item<50)
            {
                return 1;
            }
            else if (item < 60)
            {
                return 2;
            }
            else if (item < 70)
            {
                return 3;
            }
            else if(item < 85)
            {
                return 4;
            }
            else
            {
                return 5;
            }
        }

        
            
        
    }
}
