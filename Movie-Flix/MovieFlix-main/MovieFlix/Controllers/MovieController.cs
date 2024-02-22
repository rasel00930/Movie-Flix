using MovieFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieFlix.Controllers
{
    public class MovieController : Controller
    {
        MovieFlixEntities db = new MovieFlixEntities();
        // GET: Movie
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MovieAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MovieAdd([Bind(Include = "movieName , reliseDate, trailerLink, movieDetailes,moviePoster, detailesPoster, moviePrice")] MovieList movie)
        {
            if(movie.movieName!=" ")
            {
            if(ModelState.IsValid)
            {
                db.MovieLists.Add(movie);
                db.SaveChanges();
                ViewBag.msg = "";
                return View();
            }
            return View();
            }
            return View();
        }
       
    }
}