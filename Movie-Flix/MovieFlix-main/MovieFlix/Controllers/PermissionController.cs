using MovieFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieFlix.Controllers
{
    public class PermissionController : Controller
    {
        MovieFlixEntities db = new MovieFlixEntities();
        // GET: Permission
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Permission_request()
        {
            //List<payment> request = db.payments.Where(x => x.Permisson != "Yes").ToList();
            string sql = "select * from payment";
            List<payment> request = db.payments.SqlQuery(sql).ToList();
            ViewBag.Requests = request;
 
            return View();
        }
    }
}