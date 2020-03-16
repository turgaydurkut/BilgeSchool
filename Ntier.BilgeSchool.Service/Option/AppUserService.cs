using Ntier.BilgeSchool.Model.Entity;
using Ntier.BilgeSchool.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntier.BilgeSchool.Service.Option
{
    public class AppUserService:BaseService<AppUser>
    {
        public bool CheckLogin(string userName, string password)
        {
            return Any(x => x.UserName== userName && x.Password == password);
        }
        public bool CheckUserName(string userName)
        {
            return Any(x => x.UserName == userName);
        }

        public AppUser FindByUserName(string userName)
        {
            return GetByDefault(x => x.UserName == userName);
        }
    }
}
