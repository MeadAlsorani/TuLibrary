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
    public class BookTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        UserAuthentication UserAuthentication = new UserAuthentication();
        // GET: BookType
        public ActionResult Index()
        {            
            if (UserAuthentication.UserCheck(1))
            {
                return View(db.Book_Type.ToList());
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
            
        }

        // GET: BookType/Details/5
        public ActionResult Details(int? id)
        {
            if (UserAuthentication.UserCheck(1))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Book_Type book_Type = db.Book_Type.Find(id);
                if (book_Type == null)
                {
                    return HttpNotFound();
                }
                return View(book_Type);
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
            
        }

        // GET: BookType/Create
        public ActionResult Create()
        {
            if (UserAuthentication.UserCheck(1))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
            
        }

        // POST: BookType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type_Name")] Book_Type book_Type)
        {
            if (ModelState.IsValid)
            {
                db.Book_Type.Add(book_Type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book_Type);
        }

        // GET: BookType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (UserAuthentication.UserCheck(1))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Book_Type book_Type = db.Book_Type.Find(id);
                if (book_Type == null)
                {
                    return HttpNotFound();
                }
                return View(book_Type);
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
            
        }

        // POST: BookType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type_Name")] Book_Type book_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book_Type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book_Type);
        }

        // GET: BookType/Delete/5
        public ActionResult Delete(int? id)
        {            
            if (UserAuthentication.UserCheck(1))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Book_Type book_Type = db.Book_Type.Find(id);
                if (book_Type == null)
                {
                    return HttpNotFound();
                }
                return View(book_Type);
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }

            
        }

        // POST: BookType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book_Type book_Type = db.Book_Type.Find(id);
            db.Book_Type.Remove(book_Type);
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
