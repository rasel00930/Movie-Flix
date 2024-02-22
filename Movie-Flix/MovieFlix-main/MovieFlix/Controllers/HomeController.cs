using MovieFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieFlix.Controllers
{
    public class HomeController : Controller
    {
        MovieFlixEntities db = new MovieFlixEntities();
        
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            //if (Session["login"].Equals("yes"))
            //{
            //    ViewBag.userId = Session["userId"];
            //}
            //else
               

            string sql = "select * from MovieList";
            List<MovieList> movielist = db.MovieLists.SqlQuery(sql).ToList();
            ViewBag.movielist = movielist;
            return View();
        }
        public ActionResult LoginPage1()
        {
            ViewBag.error = "";
            return View();
        }
        [HttpPost]
        public ActionResult LoginPage1([Bind(Include = "email , passwords, userType")] User user)
        {
            ViewBag.person = "nobody";
            if (ModelState.IsValid)
            {
                User admin = db.Users.Where(x => x.email == user.email && x.passwords == user.passwords && x.userType == "admin").FirstOrDefault();
                User user1 = db.Users.Where(x => x.email == user.email && x.passwords == user.passwords && x.userType == "user").FirstOrDefault();
                string sql = "select * from MovieList";
                List<MovieList> movielist = db.MovieLists.SqlQuery(sql).ToList();
                ViewBag.movielist = movielist;


                if (user1 != null)
                {
                    ViewBag.error = "";
                    ViewBag.person = "user";

                    Session["login"] = "yes";
                    Session["userId"] = user1.userId;
                    // ID_pass ids = new ID_pass { userId = user.userId };

                    return RedirectToAction("Home", "Home");
                    //return View("~/Views/Home/Home.cshtml");
                    //return RedirectToAction("Home", "HomeController", new { userId = user.userId });

                }
                else if (admin != null)
                {
                    ViewBag.person = "admin";
                    ViewBag.error = "";
                    return View("~/Views/Home/Home.cshtml");
                   // return RedirectToAction("Home", "HomeController");
                }
                else
                {
                    ViewBag.error = "Invalid Email or Password";
                }

            }
            return View();

        }
    }
}