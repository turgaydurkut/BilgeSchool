using System.Web.Mvc;

namespace Ntier.BilgeSchool.Ui.Areas.StudentInformation
{
    public class StudentInformationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "StudentInformation";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "StudentInformation_default",
                "StudentInformation/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}