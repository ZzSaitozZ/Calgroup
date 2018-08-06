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
            CalgroupEntities cgi = new CalgroupEntities();
            return View(cgi.SanPhams.ToList());            
        }

        public ActionResult ChiTiet(string name)
        {            
            CalgroupEntities cgi = new CalgroupEntities();
            if (name == null)
                return View(cgi.SanPhams.ToList());
            else return View(cgi.SanPhams.Where(x => x.Name == name).ToList());
        }

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

        }
    }
}