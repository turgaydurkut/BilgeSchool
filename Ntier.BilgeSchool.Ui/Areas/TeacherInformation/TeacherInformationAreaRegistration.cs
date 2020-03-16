using System.Web.Mvc;

namespace Ntier.BilgeSchool.Ui.Areas.TeacherInformation
{
    public class TeacherInformationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TeacherInformation";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TeacherInformation_default",
                "TeacherInformation/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}