using Ntier.BilgeSchool.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntier.BilgeSchool.Model.Entity
{
    public class SuccessList:CoreEntity//Başarı Listesi
    {
        public SuccessList()
        {
            this.Students = new List<Student>();
        }
        public string ListName { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}
