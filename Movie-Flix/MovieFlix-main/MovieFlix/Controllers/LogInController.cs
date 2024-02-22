using MovieFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieFlix.Controllers
{
    public class LogInController : Controller
    {
        MovieFlixEntities db = new MovieFlixEntities();
        // GET: LogIn
        public ActionResult Index()
        {
            return View("Home");
        }
        public ActionResult LoginPage()
        {
            Variable.user_login = 0;
            Variable.errorLonin = "";
          
            Session["LogIn"] = "over";
            return View();
            
        }
        [HttpPost]
        public ActionResult LoginPage([Bind(Include = "email , passwords, userType")] User user)
        {
            ViewBag.person = "nobody";

            if (ModelState.IsValid)
            {
                
                User admin = db.Users.Where(x => x.email == user.email && x.passwords == user.passwords && x.userType == "admin").FirstOrDefault();
                User user1 = db.Users.Where(x => x.email == user.email && x.passwords == user.passwords && x.userType == "user").FirstOrDefault();
                string sql = "select * from MovieList";
                List<MovieList> movielist = db.MovieLists.SqlQuery(sql).ToList();
                ViewBag.movielist = movielist;

                Variable.commentError = "";

                if (user1 != null)
                {
                    Variable.errorLonin = "";
                    ViewBag.person = "user";
                    Variable.user_login = 1;
                    Variable.user_Id = user1.userId;
                    Variable.user_name = user1.name;
                    Session["LogIn"] ="start";
                    Variable.commentError = "";


                    return View("~/Views/Home/Home.cshtml");
                    

                }
                else if (admin != null)
                {
                    
                    Variable.user_login = 1;
                    Variable.user_Id = admin.userId;
                    Variable.user_name = admin.name;
                    Session["LogIn"] = "start";
                    ViewBag.person = "admin";
                    Variable.errorLonin = "";
                    Variable.commentError = "";
                    return View("~/Views/Home/Home.cshtml");
                
                }
                else
                {
                    Variable.errorLonin = "Invalid Email or Password!";
                    return View();
                }
            }
            return View();

        }


        public ActionResult RegisterPage()
        {
            ViewBag.notMatch = "";
            return View();
        }
        [HttpPost]
        public ActionResult RegisterPage([Bind(Include = "email ,name, passwords, confirmPass")] User1 user1)
        {
            ViewBag.notMatch = "";
            if (user1.passwords!=user1.confirmPass)
            {
                ViewBag.notMatch = "Password Did't Match, Try Again.";
                return View();
            }
            else if(user1.email!=""&& user1.name != "" && user1.passwords != "" && user1.confirmPass != "" )
            {
                if (ModelState.IsValid)
                {
                    User user = new User();
                    user.email = user1.email;
                    user.name = user1.name; 
                    user.passwords = user1.passwords;

                    db.Users.Add(user);
                    db.SaveChanges();
                    ViewBag.notMatch = "Account Registation Done.";
                    return View();
                }
            }
            else
            {
                
                return View();
            }
            return View();
        }
    }
}