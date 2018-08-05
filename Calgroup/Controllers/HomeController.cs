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

        public ActionResult SanPham(string cat)
        {
            
            return View();
        }

        public ActionResult ChiTiet(string name)
        {
            CalgroupEntities cgi = new CalgroupEntities();            
            return View(cgi.SanPhams.ToList());
        }
    }
}