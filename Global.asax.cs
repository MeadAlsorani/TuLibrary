using System.Web.Mvc;
using System.Web.Routing;
using TuLibrary.Models;
using GeneralFunctions;
namespace TuLibrary
{
    public class MvcApplication : System.Web.HttpApplication
    {
        ApplicationDbContext db = new ApplicationDbContext();
        Class1 cs = new Class1();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            //Add Admin user when the application starts for first time
            string HashedPass = cs.Hashing("maadsorani24");
            User user = new User
            {
                RoleId = 1,
                Name = "Admin",
                Password = HashedPass,
                Email = "maadsorani24@hotmail.com"
            };

            db.Users.Add(user);
            db.SaveChanges();
        }
    }
}
