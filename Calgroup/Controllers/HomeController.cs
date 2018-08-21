using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Calgroup.VM;
using Calgroup.Models;
using System.Web.Script.Serialization;
using Model.EF;

namespace Calgroup.Controllers
{
    public class HomeController : Controller
    {
        private ProductsdbContext db = new ProductsdbContext();
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

        public ActionResult SanPham(string aliascat)
        {
            Calgroup_v2DB cgi = new Calgroup_v2DB();
            var a = cgi.Database.SqlQuery<Menu>("Select Linhvuc,Category,AliasCat from dbo.MenuSP order by DisplayOrder ASC").ToList();
            SanPhamPageVM pageVM = new SanPhamPageVM(a);
            pageVM.AliasCat = aliascat;
            return View(pageVM);
        }
        [HttpPost]
        public JsonResult getSanPham(string aliascat)
        {
            Calgroup_v2DB cgi = new Calgroup_v2DB();
            var temp = cgi.getProducts(aliascat).ToList();
            getSanPhamVM pageVM = new getSanPhamVM();

            if (temp.Any())
            {
                pageVM.Products = new JavaScriptSerializer().Serialize(temp);
                pageVM.CategoryVi = temp[0].Category.Substring(0, temp[0].Category.IndexOf("/"));
            }
            else
            {
                if (aliascat == "" || aliascat == null)
                {
                    pageVM.Products = new JavaScriptSerializer().Serialize(cgi.Database.SqlQuery<ShortProduct>("Select Name,Alias,Category,Model,Manufacturer,ImageLink FROM dbo.ShortProducts where Hot is not null  order by Hot asc").ToList());
                    pageVM.CategoryVi = "Sản phẩm đang hot";
                }
                else pageVM.CategoryVi = "Hiện chưa có loại sản phẩm này";
            }
            return Json(pageVM, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ChiTiet(string alias)
        {
            Calgroup_v2DB cgi = new Calgroup_v2DB();
            if (alias != null)
            {
                var a = cgi.getProductDetail(alias).ToList();
                if (a.Any()) { return View(a); }
            }
            return RedirectToRoute("Category", new { });
        }
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
        }
        public ActionResult Library()
        {
            return View();

        }
        public ActionResult Calibration()
        {
            ViewBag.calibration = new CalibrationDAO().ListAllCalibration();
            return View();

        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult SaveContact(FormCollection collection)
        {

            String Name = Request.Form["inputName"].ToString();
            String Email = Request.Form["inputEmail"].ToString();
            String Address = Request.Form["inputAddress"].ToString();
            String Message = Request.Form["comment"].ToString();
            Customer customer = new Customer();
            customer.Name = Name;
            customer.Adress = Address;
            customer.Email = Email;
            customer.Comment = Message;
            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}