using MovieFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
namespace MovieFlix.Controllers
{
    public class MovieDetailesController : Controller
    {
        MovieFlixEntities db = new MovieFlixEntities();
        // GET: MovieDetailes
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detailes()
        {
            Variable.paymentErrorPhn = "";
            Variable.paymentErrortx = "";
            return View();

        }

        [HttpPost]
        public ActionResult Detailes([Bind(Include= "movieID ,moivePrice")] MovieList id)
        {


            //  List<Comment> com = db.Comments.Where(x => x.movieId == id.movieID).ToList();
            Variable.paymentErrorPhn = "";
            Variable.paymentErrortx = "";

            List<Comment1> com = db.Comment1.Where(x => x.movieId == id.movieID).ToList();

          
            ViewBag.com = com;
            var movieId = id.movieID;
            ID_pass ids = new ID_pass()
            {
                movieId = id.movieID,
                userId = Convert.ToInt32(id.moivePrice)
            };

            if (ModelState.IsValid)
            {
                MovieList movieDetailes = db.MovieLists.Where(x => x.movieID == id.movieID).FirstOrDefault();
               
                ViewBag.movieDetailes = movieDetailes;
                Variable.purchaseMovieID =Convert.ToString(id.movieID);
                Variable.movieName = movieDetailes.movieName;
                Variable.moviePrice = movieDetailes.moivePrice;
                Variable.purchaseMovieID =Convert.ToString(movieDetailes.movieID);
                Variable.movieLink = movieDetailes.movieLink;
                ViewBag.ids = ids;
                return View();
            }

            return Content("Could't Find Your Movie");

        }

        
    }
}