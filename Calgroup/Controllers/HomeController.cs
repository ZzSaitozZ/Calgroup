using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calgroup.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
<<<<<<< HEAD

        public ActionResult SanPham(string cat)
        {
            
            return View();
        }

        public ActionResult ChiTiet(string name)
        {
            CalgroupEntities cgi = new CalgroupEntities();            
            return View(cgi.SanPhams.ToList());
=======
        // Downy-Code
        public ActionResult News()
        {
            return View();
        }

        public ActionResult NewsDetail()
        {
            return View();
        }
        public ActionResult Question()
        {
            return View();
>>>>>>> 8a79c6288ce2ec5cdc74b2de218478db6a48986f
        }
    }
}