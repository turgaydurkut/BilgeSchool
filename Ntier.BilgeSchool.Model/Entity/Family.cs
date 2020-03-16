using Ntier.BilgeSchool.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntier.BilgeSchool.Model.Entity
{
   public class Family:CoreEntity//Veli
    {
        public Family()
        {
            this.Students = new List<Student>();
            this.Messages = new List<Message>();
        }

        [Required(ErrorMessage = "Lütfen Veli Adınızı yazın")]
        [Display(Name ="Veli Adı")]
        public string Name { get; set; }
       

        [Required(ErrorMessage = "Lütfen Veli Soyadını yazın")]
        [Display(Name = "Veli SoyAdı")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Lütfen Telefon No yazın")]
        [Display(Name = "Telefon No")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Lütfen Adres yazın")]
        
        public string Adress { get; set; }


        
        public virtual List<Message> Messages { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}
