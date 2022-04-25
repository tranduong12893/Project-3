using CourseManagement.Models;
using CourseManagement.Models.CourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseManagement.Controllers
{
    public class HomeController : Controller
    {
        private CoureseContext db = new CoureseContext();

        public ActionResult Index()
        {
            if(ValidateUser.IsUserLogin())
            {
                ViewBag.totalCourse = db.courses.Count();
                ViewBag.totalStudenRegister = db.students_register.Where(a => a.status == 1).Count();
                return View();
            }
          
            return RedirectToAction("Login", "User");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}