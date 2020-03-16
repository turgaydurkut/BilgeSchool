using Ntier.BilgeSchool.Model.Entity;
using Ntier.BilgeSchool.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntier.BilgeSchool.Service.Option
{
    public class StudentService:BaseService<Student>
    {
        public string GetStudentNumber(int item)
        {
            return (item + 100) + "-" + (DateTime.Now.Year % 1000);
        }
    }
}
