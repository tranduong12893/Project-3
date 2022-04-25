using CourseManagement.Models;
using CourseManagement.Models.CourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CourseManagement.Controllers
{
    public class HomepageController : Controller
    {
        private CoureseContext db = new CoureseContext();
        private CoureseContext courseContext = new CoureseContext();

        // GET: Homepage
        public ActionResult Index(int? category_id, string searchString)
        {
            ViewBag.categories = db.categories.ToList();
            ViewBag.courses = courseContext.courses.ToList();
         
            ViewBag.activeHome = "active";
            return View();
        }

        public ActionResult CourseDetail(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cours cours = db.courses.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            ViewBag.activeCourse = "active";
            ViewBag.courses_types = courseContext.courses_type.ToList();
            return View(cours);
        }

        // GET: Course
        public ActionResult Course(String name = "")
        {
           
            var courses = courseContext.courses;
            ViewBag.activeCourse = "active";
            return View(courses.ToList());
            
        }


        // GET: Homepage
        public ActionResult Contact()
        {
            ViewBag.categories = db.categories.ToList();
            ViewBag.branchs = db.branchs.ToList();
            ViewBag.activeContact = "active";
            return View();
        }

        // GET: Homepage
        public ActionResult Question()
        {
            ViewBag.activeQuestion = "active";
            ViewBag.questions = db.questions.ToList();
            return View();
        }

        // GET: Homepage
        public ActionResult About()
        {
            ViewBag.categories = db.categories.ToList();
            ViewBag.activeAbout = "active";
            ViewBag.abouts = courseContext.settings.Where(a => a.type == "about_us").First();
            ViewBag.abouts1 = courseContext.settings.Where(a => a.type == "about_us1").First();
            ViewBag.abouts2 = courseContext.settings.Where(a => a.type == "about_us2").First();
            ViewBag.abouts3 = courseContext.settings.Where(a => a.type == "about_us3").First();
            return View();
        }

        // GET: Homepage
        public ActionResult Login()
        {
            ViewBag.categories = db.categories.ToList();
            return View();
        }

        // GET: Homepage
        public ActionResult Register()
        {
            ViewBag.course_id = new SelectList(courseContext.courses, "id", "course_name");
            ViewBag.course_type_id = new SelectList(courseContext.courses_type.Select( c=> new
            {
                id = c.id,
                name = c.name + " - $" + c.price
            }), "id", "name");
            ViewBag.categories = db.categories.ToList();
            
            return View();
        }

        public ActionResult Search(string studentCode = "")
        {
            var student = db.students.Where(a => a.student_code.Equals(studentCode)).FirstOrDefault();
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.studentDetail = db.courses_student.Where(a => a.student_id == student.id && a.score > 0).ToList();
            ViewBag.activeAbout = "active";
            ViewBag.abouts = courseContext.settings.Where(a => a.type == "about_us").First();
            ViewBag.abouts1 = courseContext.settings.Where(a => a.type == "about_us1").First();
            ViewBag.abouts2 = courseContext.settings.Where(a => a.type == "about_us2").First();
            ViewBag.abouts3 = courseContext.settings.Where(a => a.type == "about_us3").First();
            return View();
        }

        // POST: StudentRegister/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "id,name,phone_number,email,address,date_of_birth,status,course_type_id,course_id,pracetice, payment_method")] students_register students_register)
        {
            if (ModelState.IsValid)
            {
                if(students_register.payment_method == 2)
                {
                    students_register.status = 2;
                    student student = new student();
                    student.student_name = students_register.name;                 
                    student.student_code = this.RandomString(10);
                    student.phone_number = students_register.phone_number;
                    student.email =     students_register.email;
                    student.address = students_register.address;
                    student.date_of_birth = students_register.date_of_birth;

                    db.students.Add(student);
                    courses_student courseStudent = new courses_student();
                    courseStudent.student_id = student.id;
                    courseStudent.course_id = students_register.course_id;
                    courseStudent.pracetice = students_register.pracetice;
                    db.courses_student.Add(courseStudent);
                } else
                {
                    students_register.status = 1;
                }
                
                db.students_register.Add(students_register);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.course_id = new SelectList(db.courses, "id", "course_name", students_register.course_id);
            ViewBag.course_type_id = new SelectList(db.courses_type, "id", "name", students_register.course_type_id);
            ViewBag.activeRegister = "active";
            return View(students_register);
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