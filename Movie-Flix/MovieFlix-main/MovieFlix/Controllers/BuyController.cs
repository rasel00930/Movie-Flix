using MovieFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Windows;

namespace MovieFlix.Controllers
{
    public class BuyController : Controller
    {
        MovieFlixEntities db = new MovieFlixEntities();
        // GET: Buy
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BuyMovie()
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
            if (flag == 1)
            {
                Response.Write("<script class=\"alert alert-warning\">\r\n    " +
                    "        alert('You have Already purchase');\r\n          " +
                    "  window.location.href = 'https://localhost:44391/Home/Home'\r\n    " +
                    "    </script>");

            }
            return View();
        }
        [HttpPost]
        public ActionResult BuyMovie([Bind(Include = "userId,movieId,mobileNo ,TransId, permisson")] payment pay)
        {

            if (pay.mobileNo != " " && Regex.IsMatch(pay.mobileNo, @"^[0-9]+$") && pay.TransId!=" " )
            {
                      
                if (ModelState.IsValid)
               {
                db.payments.Add(pay);
                db.SaveChanges();
                return View();
               }
               else
               {
                Response.Write("<script class=\"alert alert-warning\">\r\n    " +
                    "        alert('Sorry! You have to login first');\r\n      " +
                    "      window.location.href = 'https://localhost:44391/Buy/BuyMovie'\r\n    " +
                    "    </script>");

               }

            }else
            {

             Variable.paymentErrorPhn = "Invalid Phone Number and Transaction ID";
                return View();
            }
            
            

  
               
            
            return View();
        }
    }
}