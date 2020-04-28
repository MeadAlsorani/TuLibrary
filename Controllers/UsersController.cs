using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TuLibrary.Models;
using GeneralFunctions;
namespace TuLibrary.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly Class1 gf = new Class1();

        // GET: Users
        public ActionResult Index()
        {
            int sessId = Convert.ToInt32(Session["user"]);
            User userCheck = db.Users.Find(sessId);
            if (userCheck.RoleId==1)
            {
                var users = db.Users.Include(u => u.role);
                return View(users.ToList());
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            int sessId = Convert.ToInt32(Session["user"]);
            User userCheck = db.Users.Find(sessId);
            if (userCheck.RoleId == 1)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
            
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.UserRoles, "Id", "RoleName", user.RoleId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Password,Email,RoleId")] User user)
        {
            string hashedPass = gf.Hashing(user.Password);
            if (ModelState.IsValid)
            {
                user.Password = hashedPass;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.UserRoles, "Id", "RoleName", user.RoleId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            int sessId = Convert.ToInt32(Session["user"]);
            User userCheck = db.Users.Find(sessId);
            if (userCheck.RoleId == 1)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
            
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
