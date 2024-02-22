using MovieFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MovieFlix.Controllers
{
    public class CommentController : Controller
    {
        MovieFlixEntities db = new MovieFlixEntities();
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Detailes([Bind(Include = "userId, userName ,movieId , openion")] Comment1 comment)
        {


            MovieList movieDetailes = db.MovieLists.Where(x => x.movieID == comment.movieId).FirstOrDefault();
            ViewBag.movieDetailes = movieDetailes;

            if (Variable.user_login==0)
            {            
                List<Comment1> com = db.Comment1.Where(x => x.movieId == comment.movieId).ToList();
                ViewBag.com = com;
                Variable.commentError="Sorry! you have to login First";
                return View("~/Views/MovieDetailes/Detailes.cshtml");
            }
            else if (ModelState.IsValid)
            {
                db.Comment1.Add(comment);
                db.SaveChanges();
                List<Comment1> com = db.Comment1.Where(x => x.movieId == comment.movieId).ToList();
                ViewBag.com = com;
                return View("~/Views/MovieDetailes/Detailes.cshtml");
            }
        
            return View("~/Views/MovieDetailes/Detailes.cshtml");
        }
    }
}