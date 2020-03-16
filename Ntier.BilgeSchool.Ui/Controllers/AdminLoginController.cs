using Ntier.BilgeSchool.Model.Context;
using Ntier.BilgeSchool.Model.Entity;
using Ntier.BilgeSchool.Model.Entity.Enum;
using Ntier.BilgeSchool.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Ntier.BilgeSchool.Ui.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AppUser
        AppUserService appUserService = new AppUserService();

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AppUser appUser)
        {

            var user = appUserService.GetAll().Where(x => x.UserName == appUser.UserName && x.Password == appUser.Password).FirstOrDefault();
            if (user == null)
            {
                ViewBag.Error = "Böyle bir kullanıcı bulunamadı,Yeni Kayıt Oluşturunuz!!!";
                return View();
            }
            else
            {
                Session["login"] = user;
                Session["user"] = user.UserName;
                FormsAuthentication.SetAuthCookie(user.UserName, true);
                return RedirectToAction("Index", "Home",
                   new { area = "Admin" });
            }




        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }

        //#region UserUpdate
        //public ActionResult UserUpdate(int id)
        //{
        //    return View(appUserService.GetById(id));

        //}
        //[HttpPost]
        //public ActionResult UserUpdate(AppUser appUser)
        //{
        //    appUserService.Update(appUser);
        //    return RedirectToAction("Login");
        //} 
        //#endregion
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(AppUser appUser)
        {
            if (ModelState.IsValid)
            {

                if (appUserService.CheckUserName(appUser.UserName))
                {
                    ViewBag.Exists = "Üye adı daha önce alınmış";
                    return View();
                }

                else
                {

                    appUser.Role = Role.Admin;
                    appUserService.Add(appUser);
                    TempData["Kayit"] = "Kaydınız alındı,giriş yapabilirsiniz";
                    return RedirectToAction("Login", "AppUser");
                }

            }
            else
            {
                return View();
            }



        }

    }
}