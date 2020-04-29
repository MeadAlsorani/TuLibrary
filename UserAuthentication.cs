using System;
using System.Web;
using TuLibrary.Models;

namespace TuLibrary
{
    public class UserAuthentication
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public bool UserCheck(int RoleId)
        {
            if (HttpContext.Current.Session["user"]!=null)
            {
                int sessId = Convert.ToInt32(HttpContext.Current.Session["user"]);
                User user = db.Users.Find(sessId);
                if (user.RoleId == RoleId)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Home/Home");
                return false;
            }            
        }
    }
}