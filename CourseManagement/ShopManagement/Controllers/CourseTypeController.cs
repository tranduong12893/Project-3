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
    public class CourseTypeController : Controller
    {
        private CoureseContext db = new CoureseContext();

        // GET: CourseType
        public ActionResult Index()
        {
            if (!ValidateUser.IsUserLogin())
            {
                return RedirectToAction("Login", "User");
            }
            return View(db.courses_type.ToList());
        }

        // GET: CourseType/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            courses_type courses_type = db.courses_type.Find(id);
            if (courses_type == null)
            {
                return HttpNotFound();
            }
            return View(courses_type);
        }

        // GET: CourseType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,price")] courses_type courses_type)
        {
            if (ModelState.IsValid)
            {
                db.courses_type.Add(courses_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courses_type);
        }

        // GET: CourseType/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            courses_type courses_type = db.courses_type.Find(id);
            if (courses_type == null)
            {
                return HttpNotFound();
            }
            return View(courses_type);
        }

        // POST: CourseType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,price")] courses_type courses_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courses_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courses_type);
        }

        // GET: CourseType/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            courses_type courses_type = db.courses_type.Find(id);
            if (courses_type == null)
            {
                return HttpNotFound();
            }
            return View(courses_type);
        }

        // POST: CourseType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            courses_type courses_type = db.courses_type.Find(id);
            db.courses_type.Remove(courses_type);
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
