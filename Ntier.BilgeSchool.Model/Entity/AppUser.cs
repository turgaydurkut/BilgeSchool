using Ntier.BilgeSchool.Core.Entity;
using Ntier.BilgeSchool.Model.Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntier.BilgeSchool.Model.Entity
{
    public class AppUser:CoreEntity
    {

        [Required(ErrorMessage = "Lütfen adınızı yazın")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Lütfen soyadınızı yazın")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Şifre boş geçilemez!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        public Role Role { get; set; }

       
    }
}
