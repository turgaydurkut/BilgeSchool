using Ntier.BilgeSchool.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntier.BilgeSchool.Model.Entity
{
    public class Branch:CoreEntity// Branş
    {
        public Branch()
        {
            this.Teachers = new List<Teacher>();
        }

        [Required(ErrorMessage = "Lütfen Branş adınızı yazın")]
        public string BranchName { get; set; }

        public virtual List<Teacher> Teachers { get; set; }
    }
}
