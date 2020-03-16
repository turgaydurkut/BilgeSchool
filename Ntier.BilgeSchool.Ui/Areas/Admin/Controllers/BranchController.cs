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
    public class BranchController : Controller
    {
        BranchService branchService = new BranchService();
        // GET: Admin/Branch
        public ActionResult Index()
        {
            return View(branchService.GetActive());
        }

        // GET: Admin/Branch/Details/5
        public ActionResult Details(int id)
        {
            return View(branchService.GetById(id));
        }

        // GET: Admin/Branch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Branch/Create
        [HttpPost]
        public ActionResult Create(Branch branch)
        {
            try
            {
                branchService.Add(branch);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Branch/Edit/5
        public ActionResult Edit(int id)
        {
            return View(branchService.GetById(id));
        }

        // POST: Admin/Branch/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Branch branch)
        {
            try
            {

                branchService.Update(branch);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Branch/Delete/5
        public ActionResult Delete(int id)
        {
            return View(branchService.GetById(id));
        }

        // POST: Admin/Branch/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,Branch branch )
        {
            try
            {
                branchService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
