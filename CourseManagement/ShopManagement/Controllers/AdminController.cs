using CourseManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseManagement.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            if(ValidateUser.IsUserLogin())
            {
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