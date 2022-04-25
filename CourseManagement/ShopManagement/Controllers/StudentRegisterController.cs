using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CourseManagement.Models.CourseModels;
using CourseManagement.Models;
namespace CourseManagement.Controllers
{
    public class StudentRegisterController : Controller
    {
        private CoureseContext db = new CoureseContext();

        // GET: StudentRegister
        public ActionResult Index(String name = "")
        {
            if (!ValidateUser.IsUserLogin())
            {
                return RedirectToAction("Login", "User");
            }
           
            var students_register = db.students_register.Include(s => s.cours).Include(s => s.courses_type).Where(a => a.status != 2 
            && (a.name.Contains(name) || a.phone_number.Contains(name) || a.email.Contains(name) ));
            return View(students_register.ToList());
        }

        // GET: StudentRegister/Details/5
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
            students_register students_register = db.students_register.Find(id);
            if (students_register == null)
            {
                return HttpNotFound();
            }
            return View(students_register);
        }

        public ActionResult Confirm(long? id)
        {
            if (!ValidateUser.IsUserLogin())
            {
                return RedirectToAction("Login", "User");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students_register students_register = db.students_register.Find(id);
            if (students_register == null)
            {
                return HttpNotFound();
            }
            students_register.status = 2;
            db.Entry(students_register).State = EntityState.Modified;
           

            student student = new student();
            student.student_name = students_register.name;
            student.student_code = this.RandomString(10);
            student.phone_number = students_register.phone_number;
            student.email = students_register.email;
            student.address = students_register.address;
            student.date_of_birth = students_register.date_of_birth;

            courses_student courseStudent = new courses_student();
            courseStudent.student_id = student.id;
            courseStudent.course_id = students_register.course_id;
            courseStudent.pracetice = students_register.pracetice;
            db.courses_student.Add(courseStudent);

            db.students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index","StudentRegister");
        }

        // GET: StudentRegister/Create
        public ActionResult Create()
        {
            if (!ValidateUser.IsUserLogin())
            {
                return RedirectToAction("Login", "User");
            }
            ViewBag.course_id = new SelectList(db.courses, "id", "course_name");
            ViewBag.course_type_id = new SelectList(db.courses_type, "id", "name");
            return View();
        }

        // POST: StudentRegister/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,phone_number,email,address,date_of_birth,status,course_type_id,course_id,pracetice")] students_register students_register)
        {
            if (!ValidateUser.IsUserLogin())
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                db.students_register.Add(students_register);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.course_id = new SelectList(db.courses, "id", "course_name", students_register.course_id);
            ViewBag.course_type_id = new SelectList(db.courses_type, "id", "name", students_register.course_type_id);
            return View(students_register);
        }

        // GET: StudentRegister/Edit/5
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
            students_register students_register = db.students_register.Find(id);
            if (students_register == null)
            {
                return HttpNotFound();
            }
            ViewBag.course_id = new SelectList(db.courses, "id", "course_name", students_register.course_id);
            ViewBag.course_type_id = new SelectList(db.courses_type, "id", "name", students_register.course_type_id);
            return View(students_register);
        }

        // POST: StudentRegister/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,phone_number,email,address,date_of_birth,status,course_type_id,course_id,pracetice")] students_register students_register)
        {
            if (!ValidateUser.IsUserLogin())
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                db.Entry(students_register).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.course_id = new SelectList(db.courses, "id", "course_name", students_register.course_id);
            ViewBag.course_type_id = new SelectList(db.courses_type, "id", "name", students_register.course_type_id);
            return View(students_register);
        }

        // GET: StudentRegister/Delete/5
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
            students_register students_register = db.students_register.Find(id);
            if (students_register == null)
            {
                return HttpNotFound();
            }
            return View(students_register);
        }

        // POST: StudentRegister/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            if (!ValidateUser.IsUserLogin())
            {
                return RedirectToAction("Login", "User");
            }
            students_register students_register = db.students_register.Find(id);
            db.students_register.Remove(students_register);
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

        // Generates a random string with a given size.    
        public string RandomString(int size, bool lowerCase = false)
        {
            var generator = new Random();
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):   
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length = 26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)generator.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }
}
