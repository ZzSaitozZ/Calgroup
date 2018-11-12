using Calgroup.Models.DAO;
using Calgroup.Resources.Common;
using Calgroup.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Calgroup.Controllers
{
    public class HomeController : Controller
    {
        private  Calgroup_v2DB db = new  Calgroup_v2DB();
        public Layoutmodel Layout { get; set; }
        public HomeController()
        {
            Calgroup_v2DB db = new Calgroup_v2DB();
            Layout = new Layoutmodel
            {
                Nhanvien = db.Staffs.ToList(),
                Doitac = db.DoiTacs.ToList(),
                FAQ = db.Questions.ToList(),
                Lienlac = db.ContactDetails.ToList()
            };
            ViewBag.Mymodel = Layout;
        }
        public ActionResult Index()
        {
            ViewBag.news = new PostNewsDAO().ListByGroupAll();
            ViewBag.FAQ = new HomeController().Getquestions();
            ViewBag.Staff = new HomeController().Getnhanvien();
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
            List<Models.Menu> a = cgi.Database.SqlQuery<Calgroup.Models.Menu>("Select Linhvuc,Category,AliasCat from dbo.MenuSP order by DisplayOrder asc").ToList();
            SanPhamPageVM pageVM = new SanPhamPageVM(a)
            {
                AliasCat = aliascat
            };
            if (string.IsNullOrEmpty(aliascat))
            {
                ViewBag.LinkSP = cgi.Database.SqlQuery<Calgroup.Models.ShortProduct>("Select Alias FROM dbo.ShortProducts where Hot is not null  order by Hot asc").Select(x => x.Alias).ToList();
            }
            else
            {
                ViewBag.LinkSP = cgi.getProducts(aliascat).Select(x => x.Alias).ToList();
            }
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
                List<LoaiSanPham> Category = cgi.LoaiSanPhams.Where(x => x.AliasCat == aliascat).ToList();
                if (Category.Any())
                {
                    List<getProducts_Result> temp = cgi.getProducts(aliascat).ToList();
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
        public JsonResult getThuVien(string aliascat, int page)
        {
            Calgroup_v2DB cgi = new Calgroup_v2DB();
            List<getThuViens_Result> temp = cgi.getThuViens(aliascat, page).ToList();
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
                    pageVM.Products = new JavaScriptSerializer().Serialize(cgi.getThuViens("catalog", 1).ToList());
                    pageVM.CategoryVi = "Catalog";
                }
                else
                {
                    pageVM.CategoryVi = "Hiện chưa có loại này";
                }
            }
            return Json(pageVM, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChiTiet(string alias)
        {
            Calgroup_v2DB cgi = new Calgroup_v2DB();
            if (alias != null)
            {
                List<getProductDetail_Result> a = cgi.getProductDetail(alias).ToList();
                if (a.Any()) { return View(a); }
            }
            return RedirectToRoute("Category", new { });
        }

        // Downy-Code
        public ActionResult Library(string aliascat)
        {
            Calgroup_v2DB cgi = new Calgroup_v2DB();
            long? b = cgi.getNumberThuViens(aliascat).FirstOrDefault();
            if (b == null)
            {
                return RedirectToRoute("Library", new { aliascat = "catalog" });
            }

            List<Models.Menu> a = cgi.Database.SqlQuery<Calgroup.Models.Menu>("Select Name as Category,Category as Linhvuc,AliasCat from dbo.LibraryCategory order by Linhvuc DESC").ToList();
            SanPhamPageVM pageVM = new SanPhamPageVM(a)
            {
                PageCount = (int)Math.Ceiling((double)b / 6),
                AliasCat = aliascat
            };
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
            string Name = Request.Form["inputName"].ToString();
            string Email = Request.Form["inputEmail"].ToString();
            string Address = Request.Form["inputAddress"].ToString();
            string Message = Request.Form["comment"].ToString();
            Customer customer = new Customer
            {
                Name = Name,
                Adress = Address,
                Email = Email,
                Comment = Message
            };
            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Search(string searchString)
        {
            if (searchString == "" || searchString == null)
            {
                return RedirectToRoute("Category", new { });
            }
            else
            {
                Calgroup_v2DB cgi = new Calgroup_v2DB();
                List<Models.Menu> a = cgi.Database.SqlQuery<Calgroup.Models.Menu>("Select Linhvuc,Category,AliasCat from dbo.MenuSP order by DisplayOrder asc").ToList();
                SanPhamPageVM pageVM = new SanPhamPageVM(a)
                {
                    AliasCat = searchString
                };
                return View(pageVM);
            }
        }

        [HttpPost]
        public JsonResult searchSanPham(string searchString)
        {
            searchString = StringHelper.ToAlias(searchString);
            Calgroup_v2DB cgi = new Calgroup_v2DB();
            getSanPhamVM pageVM = new getSanPhamVM();
            List<searchProducts_Result> temp = cgi.searchProducts(searchString).ToList();
            if (temp.Any())
            {
                pageVM.Products = new JavaScriptSerializer().Serialize(temp);
                pageVM.CategoryVi = "Kết quả tìm kiếm";
            }
            else
            {
                pageVM.CategoryVi = "Không tìm thấy kết quả";
            }

            return Json(pageVM, JsonRequestBehavior.AllowGet);
        }

        public ActionResult News()
        {
            ViewBag.news = new PostNewsDAO().ListByGroupAll();
            return View();
        }

        public ActionResult NewsDetail(long id)
        {
            ViewBag.newsdetail = new PostNewsDAO().ViewDetail(id);
            return View();
        }

        public ActionResult FAQ(string alias)
        {
            Calgroup_v2DB cgi = new Calgroup_v2DB();
            List<Question> mymodel = cgi.Questions.ToList();
            return View(mymodel);
        }

        public IEnumerable<Question> Getquestions()
        {
            Calgroup_v2DB db = new Calgroup_v2DB();
            return db.Questions.Where(x => x.Status == true).ToList();
        }

        public IEnumerable<Staff> Getnhanvien()
        {
            Calgroup_v2DB db = new Calgroup_v2DB();
            return db.Staffs.Where(x => x.Status == true).ToList();
        }

        [HttpPost]
        public JsonResult getDetail(string alias)
        {
            Calgroup_v2DB cgi = new Calgroup_v2DB();
            System.Data.Entity.Core.Objects.ObjectResult<string> Detail = cgi.getFAQDetail(alias);
            return Json(Detail, JsonRequestBehavior.AllowGet);
        }
    }
}