using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
 
using Calgroup.Resources.Common;

namespace Calgroup.Areas.Admin.Controllers
{
    public class SanPhamsController : Controller
    {
        private Calgroup_v2DB db = new Calgroup_v2DB();

        // GET: Admin/SanPhams
        public async Task<ActionResult> Index()
        {
            var sanPhams = db.SanPhams.Include(s => s.LoaiSanPham);
            return View(await sanPhams.ToListAsync());
        }

        // GET: Admin/SanPhams/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = await db.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.CatID = new SelectList(db.LoaiSanPhams, "CatID", "Category");
            return View();
        }

        // POST: Admin/SanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Alias,Name,CatID,Model,Manufacturer,ImageLink,ImageLinkDetail,ManualLink,Detail,Specification,Price,Hot")] SanPham sanPham)
        {
            sanPham.Detail = HttpUtility.HtmlDecode(sanPham.Detail);
            sanPham.Specification = HttpUtility.HtmlDecode(sanPham.Specification);
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanPham);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CatID = new SelectList(db.LoaiSanPhams, "CatID", "Category", sanPham.CatID);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = await db.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatID = new SelectList(db.LoaiSanPhams, "CatID", "Category", sanPham.CatID);
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Alias,Name,CatID,Model,Manufacturer,ImageLink,ImageLinkDetail,ManualLink,Detail,Specification,Price,Hot")] SanPham sanPham)
        {
            sanPham.Detail = HttpUtility.HtmlDecode(sanPham.Detail);
            sanPham.Specification = HttpUtility.HtmlDecode(sanPham.Specification);
            if (ModelState.IsValid)
            {             
                db.Entry(sanPham).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CatID = new SelectList(db.LoaiSanPhams, "CatID", "Category", sanPham.CatID);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = await db.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int? id)
        {
            SanPham sanPham = await db.SanPhams.FindAsync(id);
            db.SanPhams.Remove(sanPham);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
