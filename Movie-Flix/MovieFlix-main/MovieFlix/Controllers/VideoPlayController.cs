using MovieFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieFlix.Controllers
{
    public class VideoPlayController : Controller
    {
        MovieFlixEntities db = new MovieFlixEntities();
        // GET: VideoPlay
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VideoPlay()
        {
            if (Variable.user_Id==1)
            {
            string sql = "select * from payment";
            List<payment> search_person = db.payments.SqlQuery(sql).ToList();
            int flag = 0;
            foreach (var x in search_person)
            {
                if (x.userId == Variable.user_Id && x.movieId == Convert.ToInt32(Variable.purchaseMovieID))
                {
                    flag = 1;
                    break;
                }
            }
            if (flag == 0)
            {
                Response.Write("<script class=\"alert alert-warning\">\r\n    " +
                    "        alert('Sorry! You have to purchase first');\r\n          " +
                    "  window.location.href = 'https://localhost:44391/Home/Home'\r\n    " +
                    "    </script>");

            }
            }
            else
            {
                Response.Write(" <script class=\"alert alert-warning\">\r\n        " +
                    "        alert('Sorry! You have to login first');\r\n             " +
                    "   window.location.href = 'https://localhost:44391/LogIn/LoginPage'\r\n   " +
                    "         </script>");
            }


            return View();
            
        }
    }
}