using Ntier.BilgeSchool.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntier.BilgeSchool.Model.Entity
{
    public class Message:CoreEntity//Mesajlar
    {

        public string Subject { get; set; }
        public string MessageNote { get; set; }

        public int? SenderId { get; set; }
        public int? SenderToStudentId { get; set; }
        public int? SenderToFamilyId { get; set; }


        public Teacher Sender { get; set; }
        public Student SenderToStudent { get; set; }
        public Family SenderToFamily { get; set; }


    }
}
