using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TuLibrary.Models;

namespace TuLibrary.Controllers
{
    public class Publisher_RequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Publisher_Requests
        public ActionResult Index()
        {
            int sessId = Convert.ToInt32(Session["user"]);
            User user = db.Users.Find(sessId);
            if (user.RoleId==1)
            {
                var publisher_Requests = db.Publisher_Requests.Include(p => p.Publisher);
                return View(publisher_Requests.ToList());
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
            
        }

        // GET: Publisher_Requests/Details/5
        public ActionResult Details(int? id)
        {
            int sessId = Convert.ToInt32(Session["user"]);
            User user = db.Users.Find(sessId);
            if (user.RoleId == 1)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Publisher_Requests publisher_Requests = db.Publisher_Requests.Find(id);
                if (publisher_Requests == null)
                {
                    return HttpNotFound();
                }
                return View(publisher_Requests);
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
            
        }

        // GET: Publisher_Requests/Create
        public ActionResult Create()
        {
            int SessId = Convert.ToInt32(Session["user"]);
            User user = db.Users.Find(SessId);
            if (user.RoleId == 2)
            {
                ViewBag.PublisherId = new SelectList(db.Users, "Id", "Name");
                return View();
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
        }

        // POST: Publisher_Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Request_Text,PublisherId")] Publisher_Requests publisher_Requests)
        {
            if (ModelState.IsValid)
            {
                db.Publisher_Requests.Add(publisher_Requests);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PublisherId = new SelectList(db.Users, "Id", "Name", publisher_Requests.PublisherId);
            return View(publisher_Requests);
        }


        // GET: Publisher_Requests/Delete/5
        public ActionResult Delete(int? id)
        {
            int sessId = Convert.ToInt32(Session["user"]);
            User user = db.Users.Find(sessId);
            if (user.RoleId == 1)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Publisher_Requests publisher_Requests = db.Publisher_Requests.Find(id);
                if (publisher_Requests == null)
                {
                    return HttpNotFound();
                }
                return View(publisher_Requests);
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
            
        }

        // POST: Publisher_Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Publisher_Requests publisher_Requests = db.Publisher_Requests.Find(id);
            db.Publisher_Requests.Remove(publisher_Requests);
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
