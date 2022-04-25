using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseManagement.Models;
using PagedList;

namespace CourseManagement.Controllers
{
    public class UserController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: User
        public ActionResult Index(int? page)
        {
            if (ValidateUser.IsUserLogin())
            {
                int pageNumber = (page ?? 1);
                return View(db.users.OrderBy(u => u.id).ToPagedList(pageNumber, Const.Const.PAGE_SIZE));
            }
            return RedirectToAction("Login", "User");

        }

        // GET: User/Details/5
        public ActionResult Details(long? id)
        {
            if (ValidateUser.IsUserLogin())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                user user = db.users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            return RedirectToAction("Login", "User");

        }

        // GET: User/Create
        public ActionResult Create()
        {

            if (ValidateUser.IsUserLogin())
            {
                ViewBag.roles = new List<Object>{
                       new { value = 1 , role_name = "Admin"  },
                       new { value = 2 , role_name = "Employee" }
                    };
                return View();
            }
            return RedirectToAction("Login", "User");

        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,user_name,password,user_role")] user user)
        {
            if (ValidateUser.IsUserLogin())
            {
                if (ModelState.IsValid)
                {
                    db.users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.roles = new List<Object>{
                       new { value = 1 , role_name = "Admin"  },
                       new { value = 2 , role_name = "Employee" }
                    };
                return View(user);
            }
            return RedirectToAction("Login", "User");

        }

        // GET: User/Edit/5
        public ActionResult Edit(long? id)
        {
            if (ValidateUser.IsUserLogin())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                user user = db.users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                ViewBag.roles = new List<Object>{
                       new { value = 1 , role_name = "Admin"  },
                       new { value = 2 , role_name = "Employee" }
                    };
                return View(user);
            }
            return RedirectToAction("Login", "User");

        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,user_name,password,user_role")] user user)
        {
            if (ValidateUser.IsUserLogin())
            {

                if (ModelState.IsValid)
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.roles = new List<Object>{
                       new { value = 1 , role_name = "Admin"  },
                       new { value = 2 , role_name = "User" }
                    };
                return View(user);
            }
            return RedirectToAction("Login", "User");

        }

        // GET: User/Delete/5
        public ActionResult Delete(long? id)
        {
            if (ValidateUser.IsUserLogin())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                user user = db.users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            return RedirectToAction("Login", "User");

        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            if (ValidateUser.IsUserLogin())
            {
                user user = db.users.Find(id);
                db.users.Remove(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "User");

        }

        // GET: User
        public ViewResult Login()
        {
            return View();
        }


        // POST: User/Login
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "id,user_name,password,user_role")] user user)
        {
            if (ModelState.IsValid)
            {
                var userLogin = db.users.Where(u => u.user_name == user.user_name && u.password == user.password &&( u.user_role == 1 || u.user_role == 2)).FirstOrDefault();
                if (userLogin != null)
                {
                    Session["user_name"] = userLogin.user_name;
                    Session["user_id"] = userLogin.id;
                    Session["user_role"] = userLogin.user_role.ToString();
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }

            return View(user);
        }

        // GET: User/Logout
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login", "User");
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
