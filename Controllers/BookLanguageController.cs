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
    public class BookLanguageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        UserAuthentication userAuth = new UserAuthentication();
        // GET: BookLanguage
        public ActionResult Index()
        {
            if (userAuth.UserCheck(1))
            {
                return View(db.Book_Language.ToList());
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
            
        }

        // GET: BookLanguage/Details/5
        public ActionResult Details(int? id)
        {
            if (userAuth.UserCheck(1))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Book_Language book_Language = db.Book_Language.Find(id);
                if (book_Language == null)
                {
                    return HttpNotFound();
                }
                return View(book_Language);
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
            
        }

        // GET: BookLanguage/Create
        public ActionResult Create()
        {
            if (userAuth.UserCheck(1))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
            
        }

        // POST: BookLanguage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Language")] Book_Language book_Language)
        {
            if (ModelState.IsValid)
            {
                db.Book_Language.Add(book_Language);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book_Language);
        }

        // GET: BookLanguage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (userAuth.UserCheck(1))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Book_Language book_Language = db.Book_Language.Find(id);
                if (book_Language == null)
                {
                    return HttpNotFound();
                }
                return View(book_Language);
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
            
        }

        // POST: BookLanguage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Language")] Book_Language book_Language)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book_Language).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book_Language);
        }

        // GET: BookLanguage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (userAuth.UserCheck(1))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Book_Language book_Language = db.Book_Language.Find(id);
                if (book_Language == null)
                {
                    return HttpNotFound();
                }
                return View(book_Language);
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
            
        }

        // POST: BookLanguage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book_Language book_Language = db.Book_Language.Find(id);
            db.Book_Language.Remove(book_Language);
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
