using System.Linq;
using System.Web.Mvc;
using TuLibrary.Models;
using System.Net;
using System.Web;
using GeneralFunctions;
using System.Data.Entity.Migrations;

namespace TuLibrary.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Home
        public ActionResult Home()
        {
            var books = db.Book.ToList();
            var type = db.Book_Type.ToList();
            var language = db.Book_Language.ToList();
            var publisher = db.Users.ToList();
            return View(new Book_Type_LanguageViewModel { book = books, Book_Type = type, Book_Language = language, Publisher = publisher });
        }

        public ActionResult Publisher()
        {
            var books = db.Book.ToList();
            var type = db.Book_Type.ToList();
            var language = db.Book_Language.ToList();
            var publisher = db.Users.ToList();
            return View(new Book_Type_LanguageViewModel { book = books, Book_Type = type, Book_Language = language, Publisher = publisher });
        }

        public ActionResult Language()
        {
            var books = db.Book.ToList();
            var type = db.Book_Type.ToList();
            var language = db.Book_Language.ToList();
            var publisher = db.Users.ToList();
            return View(new Book_Type_LanguageViewModel { book = books, Book_Type = type, Book_Language = language, Publisher = publisher });
        }

        public ActionResult Books()
        {
            var books = db.Book.ToList();
            var type = db.Book_Type.ToList();
            var language = db.Book_Language.ToList();
            var publisher = db.Users.ToList();
            return View(new Book_Type_LanguageViewModel { book = books, Book_Type = type, Book_Language = language, Publisher = publisher });
        }
    }
}