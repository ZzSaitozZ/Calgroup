using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;

namespace Calgroup.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            ViewBag.news = new PostNewsDAO().ListByGroupAll();
            return View();
        }
        public ActionResult NewsDetail(long id)
        {
            ViewBag.newsdetail = new PostNewsDAO().ViewDetail(id);
            return View();
        }
    }
}