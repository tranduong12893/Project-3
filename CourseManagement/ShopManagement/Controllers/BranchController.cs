using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseManagement.Models.CourseModels;
using CourseManagement.Models;

namespace CourseManagement.Controllers
{
    public class BranchController : Controller
    {
        private CoureseContext db = new CoureseContext();

        // GET: Branch
        public ActionResult Index()
        {
            if (!ValidateUser.IsUserLogin())
            {
                return RedirectToAction("Login", "User");
            }

            return View(db.branchs.ToList());
        }

        // GET: Branch/Details/5
        public ActionResult Details(long? id)
        {
            if (!ValidateUser.IsUserLogin())
            {
                return RedirectToAction("Login", "User");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            branch branch = db.branchs.Find(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // GET: Branch/Create
        public ActionResult Create()
        {
            if (!ValidateUser.IsUserLogin())
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }

        // POST: Branch/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,branch_name,address,phone_number,email")] branch branch)
        {
            if (!ValidateUser.IsUserLogin())
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                db.branchs.Add(branch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(branch);
        }

        // GET: Branch/Edit/5
        public ActionResult Edit(long? id)
        {
            if (!ValidateUser.IsUserLogin())
            {
                return RedirectToAction("Login", "User");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            branch branch = db.branchs.Find(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // POST: Branch/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,branch_name,address,phone_number,email")] branch branch)
        {
            if (!ValidateUser.IsUserLogin())
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                db.Entry(branch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(branch);
        }

        // GET: Branch/Delete/5
        public ActionResult Delete(long? id)
        {
            if (!ValidateUser.IsUserLogin())
            {
                return RedirectToAction("Login", "User");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            branch branch = db.branchs.Find(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // POST: Branch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            if (!ValidateUser.IsUserLogin())
            {
                return RedirectToAction("Login", "User");
            }
            branch branch = db.branchs.Find(id);
            db.branchs.Remove(branch);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
