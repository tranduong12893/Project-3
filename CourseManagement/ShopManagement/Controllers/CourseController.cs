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
    public class CourseController : Controller
    {
        private CoureseContext db = new CoureseContext();

        // GET: Course
        public ActionResult Index(String name = "")
        {
            if (!ValidateUser.IsUserLogin())
            {
                return RedirectToAction("Login", "User");
            }

            var courses = db.courses.Include(c => c.category).Where(a => a.course_name.Contains(name));
            return View(courses.ToList());
        }

        // GET: Course/Details/5
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
            cours cours = db.courses.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }


        // GET: Course/Create
        public ActionResult Create()
        {
            if (!ValidateUser.IsUserLogin())
            {
                return RedirectToAction("Login", "User");
            }
            ViewBag.category_id = new SelectList(db.categories, "id", "category_name");
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "id,course_name,description, short_description,category_id,start_date_plan, out_line")] cours cours)
        {
            if (!ValidateUser.IsUserLogin())
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                db.courses.Add(cours);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.category_id = new SelectList(db.categories, "id", "category_name", cours.category_id);
            return View(cours);
        }

        // GET: Course/Edit/5
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
            cours cours = db.courses.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            ViewBag.category_id = new SelectList(db.categories, "id", "category_name", cours.category_id);
            return View(cours);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id,course_name,description, short_description,category_id,start_date_plan, out_line")] cours cours)
        {
            if (!ValidateUser.IsUserLogin())
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                db.Entry(cours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category_id = new SelectList(db.categories, "id", "category_name", cours.category_id);
            return View(cours);
        }

        // GET: Course/Delete/5
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
            cours cours = db.courses.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            if (!ValidateUser.IsUserLogin())
            {
                return RedirectToAction("Login", "User");
            }
            cours cours = db.courses.Find(id);
            db.courses.Remove(cours);
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
