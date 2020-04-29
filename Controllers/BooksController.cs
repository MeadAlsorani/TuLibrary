using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TuLibrary.Models;
using GeneralFunctions;
using System.Data.Entity.Migrations;

namespace TuLibrary.Controllers
{
    public class BooksController : Controller
    {
        Class1 gf = new Class1();
        private ApplicationDbContext db = new ApplicationDbContext();
        UserAuthentication UserAuthentication = new UserAuthentication();

        // GET: Books
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                int UserId = Convert.ToInt32(Session["user"]);
                var books = db.Book.Include(b => b.language).Include(b => b.type).Where(u => u.PublisherId == UserId);
                return View(books.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["user"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Book book = db.Book.Find(id);
                Book_Language language = db.Book_Language.FirstOrDefault(b => b.Id == book.LanguageId);
                Book_Type book_Type = db.Book_Type.FirstOrDefault(t => t.Id == book.TypeId);
                if (book == null)
                {
                    return HttpNotFound();
                }
                return View(book);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        // GET: Books/Create
        public ActionResult Create()
        {
            if (Session["user"] != null)
            {
                ViewBag.LanguageId = new SelectList(db.Book_Language, "Id", "Language");
                ViewBag.TypeId = new SelectList(db.Book_Type, "Id", "Type_Name");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book, HttpPostedFileBase BookPicture)
        {
            string Random = gf.RandomString();
            string CompletPath = Random + BookPicture.FileName;
            string PicturePath = Path.Combine(Server.MapPath("~/Images/Books"), CompletPath);
            if (ModelState.IsValid)
            {
                if (BookPicture != null)
                {
                    BookPicture.SaveAs(PicturePath);
                    book.Picture = CompletPath;
                }

                int userId = Convert.ToInt32(Session["user"]);
                var User = db.Users.Find(userId);
                book.PublisherId = User.Id;
                db.Book.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.Book_Language, "Id", "Language", book.LanguageId);
            ViewBag.TypeId = new SelectList(db.Book_Type, "Id", "Type_Name", book.TypeId);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["user"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Book book = db.Book.Find(id);
                if (book == null)
                {
                    return HttpNotFound();
                }
                ViewBag.LanguageId = new SelectList(db.Book_Language, "Id", "Language", book.LanguageId);
                ViewBag.TypeId = new SelectList(db.Book_Type, "Id", "Type_Name", book.TypeId);
                return View(book);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book, HttpPostedFileBase BookPicture)
        {
            if (ModelState.IsValid)
            {
                var oldBook = db.Book.FirstOrDefault(b => b.Id == book.Id);
                if (BookPicture == null)
                {                    
                    book.Picture = oldBook.Picture;
                }
                else
                {
                    string Random = gf.RandomString();
                    string CompletPath = Random + BookPicture.FileName;
                    string PicturePath = Path.Combine(Server.MapPath("~/Images/Books"), CompletPath);
                    BookPicture.SaveAs(PicturePath);
                    book.Picture = CompletPath;

                    string OldPicturePath = Server.MapPath("~/Images/Books" + oldBook.Picture);
                    if (System.IO.File.Exists(OldPicturePath))
                    {
                        System.IO.File.Delete(OldPicturePath);
                    }
                }

                book.PublisherId = oldBook.PublisherId;

                db.Book.AddOrUpdate(book);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.Book_Language, "Id", "Language", book.LanguageId);
            ViewBag.TypeId = new SelectList(db.Book_Type, "Id", "Type_Name", book.TypeId);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["user"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Book book = db.Book.Find(id);
                if (book == null)
                {
                    return HttpNotFound();
                }
                return View(book);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Book.Find(id);
            db.Book.Remove(book);
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
