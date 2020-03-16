using Ntier.BilgeSchool.Model.Entity;
using Ntier.BilgeSchool.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ntier.BilgeSchool.Ui.Areas.Admin.Controllers
{
    public class AppUserController : Controller
    {
        AppUserService appUserService = new AppUserService();
        public ActionResult Index()
        {
            return View(appUserService.GetActive());
        }


        public ActionResult Details(int id)
        {
            return View(appUserService.GetById(id));
        }

        
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public ActionResult Create(AppUser appUser)
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

                    
                    appUserService.Add(appUser);
                    TempData["Kayit"] = "Kaydınız alındı,giriş yapabilirsiniz";
                    return RedirectToAction("Index");
                }

            }
            else
            {
                return View();
            }
        }

        
        public ActionResult Edit(int id)
        {
            return View(appUserService.GetById(id));
        }

      
        [HttpPost]
        public ActionResult Edit(AppUser appUser)
        {
            try
            {

                appUserService.Update(appUser);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

     
        public ActionResult Delete(int id)
        {
            return View(appUserService.GetById(id));
        }

        
        [HttpPost]
        public ActionResult Delete( AppUser appUser)
        {
            try
            {

                appUserService.Remove(appUser);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
