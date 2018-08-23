using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;

namespace Calgroup.Controllers
{
    public class FAQwebController : Controller
    {
        // GET: FAQ
        public ActionResult Index(string alias)
        {
            Calgroup_v2DB cgi = new Calgroup_v2DB();
            var FAQweb = cgi.Questions.ToList();
            return View(FAQweb);
        }
        [HttpPost]
        public JsonResult getDetail(string alias)
        {
            Calgroup_v2DB cgi = new Calgroup_v2DB();
            var Detail = cgi.getFAQDetail(alias);
            return Json(Detail, JsonRequestBehavior.AllowGet);
        }
    }
}