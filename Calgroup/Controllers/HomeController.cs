using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Calgroup.VM;
using Calgroup.Models;
using System.Web.Script.Serialization;


namespace Calgroup.Controllers
{
    public class HomeController : Controller
    {
        private Model.EF.ProductsdbContext db = new Model.EF.ProductsdbContext();
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
            var a = cgi.Database.SqlQuery<Calgroup.Models.Menu>("Select Linhvuc,Category,AliasCat from dbo.MenuSP order by DisplayOrder asc").ToList();
            SanPhamPageVM pageVM = new SanPhamPageVM(a);
            pageVM.AliasCat = aliascat;
            return View(pageVM);
        }
        [HttpPost]
        public JsonResult getSanPham(string aliascat)
        {
            Calgroup_v2DB cgi = new Calgroup_v2DB();         
            getSanPhamVM pageVM = new getSanPhamVM();
            if (aliascat == null || aliascat == "")
            {
                pageVM.Products = new JavaScriptSerializer().Serialize(cgi.Database.SqlQuery<Calgroup.Models.ShortProduct>("Select Name,Alias,Category,Model,Manufacturer,ImageLink FROM dbo.ShortProducts where Hot is not null  order by Hot asc").ToList());
                pageVM.CategoryVi = "Sản phẩm đang hot";
            }
            else
            {
                var Category = cgi.LoaiSanPhams.Where(x => x.AliasCat == aliascat).ToList();
                if (Category.Any())
                {
                    var temp = cgi.getProducts(aliascat).ToList();
                    pageVM.Products = new JavaScriptSerializer().Serialize(temp);
                    pageVM.CategoryVi = Category[0].Category.Substring(0, Category[0].Category.IndexOf("/"));
                }
                else
                {
                    pageVM.CategoryVi = "Hiện chưa có loại sản phẩm này";
                }
            }
            return Json(pageVM, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult getThuVien(string aliascat,int page)
        {
            Calgroup_v2DB cgi = new Calgroup_v2DB();
            var temp = cgi.getThuViens(aliascat,page).ToList();
            getSanPhamVM pageVM = new getSanPhamVM();

            if (temp.Any())
            {
                pageVM.Products = new JavaScriptSerializer().Serialize(temp);
                pageVM.CategoryVi = temp[0].Category;
            }
            else
            {
                if (aliascat == "" || aliascat == null)
                {
                    pageVM.Products = new JavaScriptSerializer().Serialize(cgi.getThuViens("catalog",1).ToList());
                    pageVM.CategoryVi = "Catalog";
                }
                else pageVM.CategoryVi = "Hiện chưa có loại này";
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
        public ActionResult Library(string aliascat)
        {
                Calgroup_v2DB cgi = new Calgroup_v2DB();
                var b = cgi.getNumberThuViens(aliascat).FirstOrDefault();
            if (b == null) return RedirectToRoute("Library", new {aliascat = "catalog" });
                var a = cgi.Database.SqlQuery<Calgroup.Models.Menu>("Select Name as Category,Category as Linhvuc,AliasCat from dbo.LibraryCategory order by Linhvuc DESC").ToList();                
                SanPhamPageVM pageVM = new SanPhamPageVM(a);            
                pageVM.PageCount = (int)Math.Ceiling((double)b/6);          
                pageVM.AliasCat = aliascat;
                return View(pageVM);
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
            Model.EF.Customer customer = new Model.EF.Customer();
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