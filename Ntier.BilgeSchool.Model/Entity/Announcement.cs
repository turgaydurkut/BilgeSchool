using Ntier.BilgeSchool.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntier.BilgeSchool.Model.Entity
{
    public class Announcement:CoreEntity//Duyuru
    {
        public string TopicName { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }

    }
}
