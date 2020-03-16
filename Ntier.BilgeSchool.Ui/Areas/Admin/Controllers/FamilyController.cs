using Ntier.BilgeSchool.Model.Entity;
using Ntier.BilgeSchool.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ntier.BilgeSchool.Ui.Areas.Admin.Controllers
{
    [Authorize]
    public class FamilyController : Controller
    {
        FamilyService familyService = new FamilyService();
        // GET: Admin/Family
        public ActionResult Index()
        {
            return View(familyService.GetActive());
        }

        // GET: Admin/Family/Details/5
        public ActionResult Details(int id)
        {
            return View(familyService.GetById(id));
        }


        // GET: Admin/Family/Edit/5
        public ActionResult Edit(int id)
        {
            return View(familyService.GetById(id));
        }

        // POST: Admin/Family/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Family family)
        {
            try
            {

                familyService.Update(family);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Family/Delete/5
        public ActionResult Delete(int id)
        {
            return View(familyService.GetById(id));
        }

        // POST: Admin/Family/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Family family)
        {
            try
            {

                familyService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
