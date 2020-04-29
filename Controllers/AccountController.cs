using System.Web.Mvc;
using TuLibrary.Models;
using GeneralFunctions;
using System.Linq;
using System;

namespace TuLibrary.Controllers
{
    public class AccountController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        Class1 c = new Class1();
        UserAuthentication UA = new UserAuthentication();
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (user.Password.Length < 8)
            {
                TempData["RegError"] = "Password must be 8 Caracters at least";
                return View();
            }

            if (ModelState.IsValid)
            {
                var userEmail = db.Users.FirstOrDefault(u => u.Email == user.Email);
                if (userEmail == null)
                {
                    user.RoleId = 2;
                    user.Password = c.Hashing(user.Password);
                    db.Users.Add(user);
                    db.SaveChanges();
                    Session["user"] = user.Id;
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    TempData["RegError"] = "This Email is alraedy Taken";
                    return View();
                }

            }
            else
            {
                return View();
            }

        }

        public ActionResult Login()
        {
            if (Session["user"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }

        }


        [HttpPost]
        public ActionResult Login(User user)
        {

            string HashedPass = c.Hashing(user.Password);
            var CredintialCheck = db.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == HashedPass);

            if (CredintialCheck != null)
            {
                int UserId = CredintialCheck.Id;
                Session["user"] = UserId;
                return RedirectToAction("Home", "Home");
            }
            else
            {
                TempData["LoginError"] = "User name or password is not correct..!!";
                return View();
            }
        }



        public ActionResult PublisherControlPanel()
        {
            if (Session["user"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }

        }


        public ActionResult AdminControlPanel()
        {
            if (UA.UserCheck(1))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
        }

    }
}