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
using Rotativa;

namespace CourseManagement.Controllers
{
    public class CourseStudentController : Controller
    {
        private CoureseContext db = new CoureseContext();

        // GET: CourseStudent
        public ActionResult Index(String name = "")
        {
            if (!ValidateUser.IsUserLogin())
            {
                return RedirectToAction("Login", "User");
            }
            var courses_student = db.courses_student.Include(c => c.cours).Include(c => c.courses_type).Include(c => c.student).Where(a => a.score == null 
            && (a.student.student_name.Contains(name) || a.cours.course_name.Contains(name) || a.student.student_code.Contains(name) ) );
            return View(courses_student.ToList());
        }

        public ActionResult PrintPDF()
        {
            if (!ValidateUser.IsUserLogin())
            {
                return RedirectToAction("Login", "User");
            }
            List<courses_student> Data = db.courses_student.Where(a => a.score == null).ToList();

            return new PartialViewAsPdf("PrintPDF", Data)
            {
                FileName = "TestPartialViewAsPdf.pdf"
            };
        }

        // GET: CourseStudent/Details/5
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
            courses_student courses_student = db.courses_student.Find(id);
            if (courses_student == null)
            {
                return HttpNotFound();
            }
            return View(courses_student);
        }

        // GET: CourseStudent/Create
        public ActionResult Create()
        {
            if (!ValidateUser.IsUserLogin())
            {
                return RedirectToAction("Login", "User");
            }
            ViewBag.course_id = new SelectList(db.courses, "id", "course_name");
            ViewBag.course_type_id = new SelectList(db.courses_type, "id", "name");
            ViewBag.student_id = new SelectList(db.students, "id", "student_code");
            return View();
        }

        // POST: CourseStudent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,student_id,course_id,course_type_id,score")] courses_student courses_student)
        {
            if (ModelState.IsValid)
            {
                db.courses_student.Add(courses_student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.course_id = new SelectList(db.courses, "id", "course_name", courses_student.course_id);
            ViewBag.course_type_id = new SelectList(db.courses_type, "id", "name", courses_student.course_type_id);
            ViewBag.student_id = new SelectList(db.students, "id", "student_code", courses_student.student_id);
            return View(courses_student);
        }

        // GET: CourseStudent/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            courses_student courses_student = db.courses_student.Find(id);
            if (courses_student == null)
            {
                return HttpNotFound();
            }
            ViewBag.course_id = new SelectList(db.courses, "id", "course_name", courses_student.course_id);
            ViewBag.course_type_id = new SelectList(db.courses_type, "id", "name", courses_student.course_type_id);
            ViewBag.student_id = new SelectList(db.students, "id", "student_code", courses_student.student_id);
            return View(courses_student);
        }

        // POST: CourseStudent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,student_id,course_id,course_type_id,score")] courses_student courses_student)
        {
            if (ModelState.IsValid)
            {
                if(courses_student.score <= 70)
                {
                    courses_student.course_type_id = 1;
                } else
                {
                    courses_student.course_type_id = 2;
                }
                db.Entry(courses_student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.course_id = new SelectList(db.courses, "id", "course_name", courses_student.course_id);
            ViewBag.course_type_id = new SelectList(db.courses_type, "id", "name", courses_student.course_type_id);
            ViewBag.student_id = new SelectList(db.students, "id", "student_code", courses_student.student_id);
            return View(courses_student);
        }

        // GET: CourseStudent/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            courses_student courses_student = db.courses_student.Find(id);
            if (courses_student == null)
            {
                return HttpNotFound();
            }
            return View(courses_student);
        }

        // POST: CourseStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            courses_student courses_student = db.courses_student.Find(id);
            db.courses_student.Remove(courses_student);
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
